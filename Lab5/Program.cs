using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        private delegate BigInteger liczniki_D(Tuple<int, int> a);
        private delegate BigInteger mianownik_D(Tuple<int, int> a);

        static BigInteger licznik_F(Tuple<int, int> a)
        {
            int tN = a.Item1;
            BigInteger temp = BigInteger.Parse("1");
            for (int i = tN; i > 0; i--) temp *= i;
            return temp;
        }
        static BigInteger mianownik_F(Tuple<int, int> a)
        {
            int tK = a.Item2;
            int tN = a.Item1;
            BigInteger temp1 = BigInteger.Parse("1");
            BigInteger temp2 = BigInteger.Parse("1");
            for (int i = tK; i > 0; i--) temp1 *= i;
            for (int i = tN-tK; i > 0; i--) temp2 *= i;
            return temp1*temp2;
        }
        static private async Task newton(Tuple<int, int> a)
        {
            Task<BigInteger> licznik_t = Task.Run(() => licznik_F(a));
            Task<BigInteger> mianownik_t = Task.Run(() => mianownik_F(a));
            var licznik = await licznik_t;
            var mianownik = await mianownik_t;
            Console.WriteLine(licznik/mianownik);
        }
        static void Main(string[] args)
        {
            Tuple<int, int> NK = new Tuple<int, int>(999,5);
            //---------zad1.1------------
            var licznik1 = Task<BigInteger>.Factory.StartNew((object a)=>{
                return licznik_F((Tuple<int, int>)a);
            },NK);
            var mianownik1 = Task<BigInteger>.Factory.StartNew((object a) => {
                return mianownik_F((Tuple<int, int>)a);
            },NK);
            licznik1.Wait();
            mianownik1.Wait();
            Console.WriteLine(licznik1.Result/mianownik1.Result);
            //---------zad1.2------------
            liczniki_D licznik_DD = licznik_F;
            mianownik_D mianownik_DD = mianownik_F;
            var licznik2 = licznik_DD.BeginInvoke(NK,null,null);
            var mianownik2 = mianownik_DD.BeginInvoke(NK, null, null);
            var i = licznik_DD.EndInvoke(licznik2);
            var z = mianownik_DD.EndInvoke(mianownik2);
            Console.WriteLine(i/z);
            //---------zad1.3------------
            Task.WaitAll(newton(NK));
            //---------zad4--------------
            string[] hostNames = { "www.microsoft.com", "www.apple.com",
                "www.google.com", "www.ibm.com", "cisco.netacad.net",
                "www.oracle.com", "www.nokia.com", "www.hp.com", "www.dell.com",
                "www.samsung.com", "www.toshiba.com", "www.siemens.com",
                "www.amazon.com", "www.sony.com", "www.canon.com", "www.acer.com", "www.motorola.com" };

            var result = from num in hostNames.AsParallel()
                            select (Dns.GetHostAddresses(num)[0], num);
            try
            {
                foreach (var k in result)
                {
                    Console.Write(k.Item1);
                    Console.Write(" => ");
                    Console.WriteLine(k.Item2);
                }
            }   
            catch (Exception) {}
        }
    }
}
