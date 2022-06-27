using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1022
{
    class PlayerIOList
    {
        #region 프로퍼티

        private readonly string id;
        public string Id { get { return id; } }

        private readonly string name;
        public string Name { get { return name; } }

        private readonly string position;
        public string Position { get { return position; } }

        private readonly string battype;
        public string Battype { get { return battype; } }

        private readonly int hit1;
        public int Hit1 { get { return hit1; } }

        private readonly int hit2;
        public int Hit2 { get { return hit2; } }

        private readonly int hit3;
        public int Hit3 { get { return hit3; } }

        private readonly int homerun;
        public int Homerun { get { return homerun; } }

        private readonly int balls;
        public int Balls { get { return balls; } }

        private readonly int dball;
        public int Dball { get { return dball; } }

        private readonly int sout;
        public int Sout { get { return sout; } }

        private readonly int pout;
        public int Out { get { return pout; } }

        #endregion

        #region 생성자

        public PlayerIOList(string _id, string _name, string _position, string _battype, 
            int _hit1, int _hit2, int _hit3, int _homerun, int _balls, int _dball, int _sout, int _out)
        {
            id = _id;
            name = _name;
            position = _position;
            battype = _battype;
            hit1 = _hit1;
            hit2 = _hit2;
            hit3 = _hit3;
            homerun = _homerun;
            balls = _balls;
            dball = _dball;
            sout = _sout;
            pout = _out;
        }

        #endregion
    }
}
