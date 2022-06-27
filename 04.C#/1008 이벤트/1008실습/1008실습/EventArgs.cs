using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 이벤트 전달 인자 객체
 * 델리게이션
 * 
 * 회원삭제에 대한 이벤트 처리 
 * [ 등록]
 * - 이벤트 전달 인자 객체
 * - 델리게이션
 * [게시자 처리]
 * - MemberManager 객체에서 이벤트 정의
 * - MebberManager 객체의 DeleteMember 함수에서 이벤트 호출 
 * [구독자 처리]
 * EventViewr 맴버 함수(이벤트핸들러 함수 정의)
 * EventView 의 생성자에서 이벤트 핸들러 함수 등록)
 * [EventViewr객체를 생성]
 * Application클래스에서  매니저객체를 생성한 후 생성코드 있다.
 */ 
namespace _1008실습
{
    #region 회원 가입
    class AddMemberEventArgs
    {
        public Member Member { get; private set; }

        public Dictionary<string, Member> MemberList { get; private set; }

        public AddMemberEventArgs(Member mem, Dictionary<string, Member> memberlist)
        {
            Member = mem;
            MemberList = memberlist;
        }
    }

    delegate void AddMemberEvent(object obj, AddMemberEventArgs e);

    #endregion
}
