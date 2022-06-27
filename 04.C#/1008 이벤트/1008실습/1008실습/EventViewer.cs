using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1008실습
{
    /// <summary>
    /// 이벤트 구독자
    /// </summary>
    class EventViewer
    {
        public EventViewer()
        {
            MemberManager mm = MemberManager.Singleton;
            mm.AddMemberEventHandler += new AddMemberEvent(AddMemberEventHandler);
        }

        void AddMemberEventHandler(object obj, AddMemberEventArgs e)
        {
            Console.WriteLine("이벤트 수신 - 회원 가입 이벤트");
            Console.WriteLine("이름:{0}, 주소:{1}", e.Member.Name, e.Member.Addr);
            Console.WriteLine("-----------------------------------");
            foreach(KeyValuePair<string, Member> pair in e.MemberList)
            {
                Console.WriteLine(pair.Value);
            }
        }
    }
}
