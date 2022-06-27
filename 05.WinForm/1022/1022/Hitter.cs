using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace _1022
{
    enum PositionType
    {
        NON,
        SACKER1,    //1루수
        SACKER2,    //2루수
        SACKER3,    //3루수
        SHORTSTOP,  //유격수
        LEFT,       //좌익수
        MID,        //중견수
        RIGHT,      //우익수
        CATCHER     //포수
    }

    enum BatterType
    { 
        NON,
        LEFTHITTER,     //좌타자
        RIGHTHITTER,    //우타자
        SWITCHHITTER    //스위치타자
    }

    class Hitter
    {
        #region 프로퍼티

        private readonly PositionType potype;
        public PositionType Potype { get { return potype; } }

        private readonly BatterType battype;
        public BatterType Battype { get { return battype; } }

        private readonly string id;
        public string Id { get { return id; } }

        private readonly string name;
        public string Name { get { return name; } }

        private int hit1;
        public int Hit1 { get { return hit1; } }

        private int hit2;
        public int Hit2 { get { return hit2; } }

        private int hit3;
        public int Hit3 { get { return hit3; } }

        private int homerun;
        public int Homerun { get { return homerun; } }

        private int balls;
        public int Balls { get { return balls; } }

        private int dball;
        public int Dball { get { return dball; } }

        private int sout;
        public int Sout { get { return sout; } }

        private int pout;
        public int Out { get { return pout; } }

        private int play;
        public int Play { get { return play; } }

        private int count;
        public int Count { get { return count; } }

        private float average;
        public float Average { get { return average; } }

        private List<PlayerIOList> plist = new List<PlayerIOList>();
        public List<PlayerIOList> Plist { get { return plist; } }

        #endregion

        #region 생성자

        public Hitter(string _id, string _name, PositionType _position, BatterType _batter)
        {
            id = _id;
            name = _name;
            potype = _position;
            battype = _batter;
            hit1 = 0;
            hit2 = 0;
            hit3 = 0;
            homerun = 0;
            balls = 0;
            dball = 0;
            sout = 0;
            pout = 0;
            play = 0;
            count = 0;
            average = 0;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(), hit1, hit2, hit3, homerun, balls, dball, sout, pout);
        }

        #endregion

        #region 메서드

        public void Update()
        {
            play = (hit1 + hit2 + hit3 + homerun + balls + dball + sout + pout) / 5;
            count = hit1 + hit2 + hit3 + homerun + sout + pout;
            average = (hit1 + hit2 + hit3+homerun) / (float)count;
        }

        public void InputPlist(string _id, string _name,string _position, string _battype,
            int hit1, int hit2, int hit3, int homerun, int balls, int dball, int sout, int _out)
        {
            Plist.Add(new PlayerIOList(_id, _name, _position, _battype, 
                hit1, hit2, hit3, homerun, balls, dball, sout, _out));
        }


        #endregion

        #region  연산

        public void Hit1Count()
        {
            hit1 += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
                hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }

        public void Hit2Count()
        {
            hit2 += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
               hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        public void Hit3Count()
        {
            hit3 += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
               hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        public void HomerunCount()
        {
            homerun += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
               hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        public void BallsCount()
        {
            balls += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
               hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        public void DballCount()
        {
            dball += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
               hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        public void SoutCount()
        {
            sout += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
                hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        public void OutCount()
        {
            pout += 1;
            InputPlist(Id, Name, Potype.ToString(), Battype.ToString(),
               hit1, hit2, hit3, homerun, balls, dball, sout, pout);
            Update();
        }
        #endregion
    }
}
