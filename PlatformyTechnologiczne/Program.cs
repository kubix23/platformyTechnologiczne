using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformyTechnologiczne
{
    static class Program
    {
        private static List<Car> myCars = new List<Car>(){
            new Car("E250", new Engine(1.8, 204, "CGI"), 2009),
            new Car("E350", new Engine(3.5, 292, "CGI"), 2009),
            new Car("A6", new Engine(2.5, 187, "FSI"), 2012),
            new Car("A6", new Engine(2.8, 220, "FSI"), 2012),
            new Car("A6", new Engine(3.0, 295, "TFSI"), 2012),
            new Car("A6", new Engine(2.0, 175, "TDI"), 2011),
            new Car("A6", new Engine(3.0, 309, "TDI"), 2011),
            new Car("S6", new Engine(4.0, 414, "TFSI"), 2012),
            new Car("S8", new Engine(4.0, 513, "TFSI"), 2012),

        };
        static void Main()
        {
            LINQ();
            ARGS();
            Application.EnableVisualStyles();
            Application.Run(new Form1(myCars));
        }

        private static void LINQ()
        {
            var methodBasedSyntaxQuery = myCars
                .Where(s => s.model.Equals("A6"))
                .Select(car => new {
                    engineType = String.Compare(car.motor.model, "TDI") == 0 ? "diesel" : "petrol",
                    hppl = car.motor.horsePower / car.motor.displacement,
                })
                .GroupBy(elem => elem.engineType)
                .Select(elem => new {
                    engineType = elem.First().engineType.ToString(),
                    avgHPPL = elem.Average(s => s.hppl).ToString()
                })
                .OrderByDescending(t => t.avgHPPL);

            var queryExpresionSyntax = from elem in (from car in myCars 
                where car.model.Equals("A6") select new {
                    engineType = String.Compare(car.motor.model, "TDI") == 0 ? "diesel" : "petrol",
                    hppl = car.motor.horsePower / car.motor.displacement,
                })
                group elem by elem.engineType into elemGrouped
                select new
                {
                    engineType = elemGrouped.First().engineType.ToString(),
                    avgHPPL = elemGrouped.Average(s => s.hppl).ToString()
                } into elemSelected
                orderby elemSelected.avgHPPL descending
                select elemSelected;

            foreach (var e in methodBasedSyntaxQuery) Console.WriteLine(e.engineType + ": " + e.avgHPPL);
            Console.WriteLine();
            foreach (var e in queryExpresionSyntax) Console.WriteLine(e.engineType + ": " + e.avgHPPL);
        }

        private static void ARGS()
        {
            Func<Car,Car,int> arg1 = compare;
            Predicate<Car> arg2 = tdi;
            Action<Car> arg3 = show;
            myCars.Sort(new Comparison<Car>(arg1));
            myCars.FindAll(arg2).ForEach(arg3);
        }

        private static int compare(Car car1, Car car2)
        {
            return car1.motor.horsePower >= car2.motor.horsePower ? -1 : 1;
        }
        private static bool tdi(Car car1)
        {
            return car1.motor.model != "TDI";
        }
        private static void show(Car car1)
        {
            string message = $"{car1.model} {car1.motor} ({car1.year})";
            DialogResult result = MessageBox.Show(message);
        }
    }
}
