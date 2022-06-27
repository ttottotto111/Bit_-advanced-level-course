using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1021
{
    class Simulation
    {
        public int Count { get; set; }
        public int Inputcount { get; set; }
        public int Outputcount { get; set; }
        public int Balance { get; set; }

        public Simulation()
        {
            Count = 0;
            Inputcount = 0;
            Outputcount = 0;
            Balance = 0;
        }
    }
}
