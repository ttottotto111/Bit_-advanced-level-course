using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1022
{
    class PlayerManager
    {
        #region 싱글톤
        //1. 생성자 은닉
        private PlayerManager()
        {

        }
        //2. 프로퍼티 선언
        static public PlayerManager Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static PlayerManager()
        {
            Singleton = new PlayerManager();
        }
        #endregion

        private Dictionary<string, Hitter> plist = new Dictionary<string, Hitter>();
        public Dictionary<string, Hitter> Plist { get { return plist; } }

        //선수생성
        public bool InsertPlayer(string id, string name, PositionType position, BatterType bat)
        {
            try
            {
                Hitter hit = null;
                hit = new Hitter(id, name, position, bat);

                plist.Add(id, hit);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //등번호로 검색
        public Hitter IdToAccount(string id)
        {
            return plist[id];
        }

        //선수 이름으로 검색
        public List<Hitter> NameToAccount(string name)
        {
            List<Hitter> temp = new List<Hitter>();

            foreach (KeyValuePair<string, Hitter> data in plist)
            {
                if (data.Value.Name.Equals(name) == true)
                {
                    temp.Add(data.Value);
                }
            }
            return temp;
        }

        //업데이트
        public void Update(string id, int number)
        {
            if (number == 1)
            {
                IdToAccount(id).Hit1Count();
            }
            else if (number == 2)
            {
                IdToAccount(id).Hit2Count();
            }
            else if (number == 3)
            {
                IdToAccount(id).Hit3Count();
            }
            else if (number == 4)
            {
                IdToAccount(id).HomerunCount();
            }
            else if (number == 5)
            {
                IdToAccount(id).BallsCount();
            }
            else if (number == 6)
            {
                IdToAccount(id).DballCount();
            }
            else if (number == 7)
            {
                IdToAccount(id).SoutCount();
            }
            else if (number==0||number == 8)
            {
                IdToAccount(id).OutCount();
            }
        }
    }
}
