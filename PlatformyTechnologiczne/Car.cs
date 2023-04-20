using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyTechnologiczne
{
    partial class Car
    {

        public string model { get; set; }
        public Engine motor { get; set; }
        public int year { get; set; }
        public Car() => (model, motor, year) = ("", new Engine(), 0);
        public Car(string model, Engine motor, int year) =>
            (this.model, this.year, this.motor) = (model, year, motor);

    }
    partial class Car
    {
        public static implicit operator Car(string s)
        {
            return new Car();
        }
    }
}
