using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformyTechnologiczne
{
    partial class Engine
    {
        public double displacement { get; set; }
        public double horsePower { get; set; }
        public string model { get; set; }

        public Engine() => (this.displacement, this.horsePower, this.model) = (0.0,0.0,"");
        public Engine(double displacement, double horsePower, string model) => 
            (this.displacement, this.horsePower, this.model) = (displacement, horsePower, model);

        public override string ToString()
        {
            return $"{model} {displacement} ({horsePower} hp)";
        }
    }

    partial class Engine : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj is Engine)
            {
                return this.horsePower.CompareTo(((Engine)obj).horsePower);
            }
            return 1;
        }
    }
}
