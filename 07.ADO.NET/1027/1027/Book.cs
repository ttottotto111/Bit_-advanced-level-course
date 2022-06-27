using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027
{
    class Book
    {
        public int PID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public Book(int _pid, string _name, int _price, string _des)
        {
            PID = _pid;
            Name = _name;
            Price = _price;
            Description = _des;
        }
    }
}
