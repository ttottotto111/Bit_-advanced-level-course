using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace _1124WCFService
{
    //델리게이트 정의
    public delegate void Chat(string idx, string msg, string type);

    class ChatService : IChat
    {
        //동기화 작업을 위해서 가상의 객체 생성[추가]
        private static Object syncObj = new Object();

        //채팅방에 있는 유저 이름 목록[추가]
        private static List<string> Chatter = new List<string>();

        //개인용 델리게이트
        private Chat MyChat;

        //1대 다 통신을 위한 클라이언트에 보낼 정보를 담고 있는 델리게이트[추가]
        private static Chat List;

        IChatCallback callback = null;        


        #region IChat 인터페이스 
        public bool Join(string idx)
        {
            MyChat = new Chat(UserHandler);

            lock (syncObj)  //동기화 된 상태에서 List에 추가
            {
                if (!Chatter.Contains(idx))
                {
                    //2. 사용자에게 보내 줄 채널을 설정한다.
                    callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();

                    //델리게이트에 추가
                    List += MyChat;

                    //현재 접속자 정보를 모두에게 전달
                    BroadcastMessage(idx, "", "UserEnter");
                   
                    return true;
                }
                return false;
            }
        }

        public void Leave(string idx)
        {
            List -= MyChat;
            Chat d = null;
            MyChat -= d;
            BroadcastMessage(idx, "", "UserLeave");
        }

        public void Say(string idx, string msg)
        {
            BroadcastMessage(idx, msg, "Receive");
        }
        #endregion 

        private void BroadcastMessage(string idx, string msg, string msgType)
        {
            //1대 다 통신
            //비동기로 UserHandler 함수 호출
            if (List != null)
            {
                foreach (Chat handler in List.GetInvocationList())
                {
                    handler.BeginInvoke(idx, msg, msgType, new AsyncCallback(EndAsync), null);
                }
            }
        }

        //클라이언트에 메시지 보내기
        private void UserHandler(string idx, string msg, string msgType)
        {
            try
            {
                //클라이언트에게 보내기
                switch (msgType)
                {
                    //메시지 전송
                    case "Receive":     callback.Receive(idx, msg); break;
                    //채팅 참여 알림
                    case "UserEnter":   callback.UserEnter(idx);    break;
                    //채팅 나감 알림
                    case "UserLeave":   callback.UserLeave(idx);    break;
                }
            }
            catch//에러가 발생했을 경우
            {
                Console.WriteLine("{0} 에러", idx);
                Leave(idx);
            }
        }

        //비동기 결과 호출[기능은 없음]
        private void EndAsync(IAsyncResult ar)
        {
            Chat d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((Chat)asres.AsyncDelegate);
                d.EndInvoke(ar);
            }
            catch
            {
                List -= d;
            }
        }
    }
}
