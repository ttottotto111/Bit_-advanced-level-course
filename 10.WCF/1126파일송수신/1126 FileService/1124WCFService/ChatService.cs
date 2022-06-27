using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace _1124WCFService
{
    //델리게이트 정의
    public delegate void FileSend(string filename, byte[] data);
    
    
    class ChatService : IFile
    {
        //동기화 작업을 위해서 가상의 객체 생성[추가]
        private static Object syncObj = new Object();        

        //개인용 델리게이트
        private FileSend MyFile;

        //1대 다 통신을 위한 클라이언트에 보낼 정보를 담고 있는 델리게이트[추가]
        private static FileSend ClientList;

        IFileCallback callback = null;     
        
        public ChatService()
        {                     
           

            Console.WriteLine("인스턴스 생성");
        }

        #region IFile
        public bool UploadFile(string strFileName, byte[] bytePic)
        {
            //1. 자신의 디렉토리에 파일을 저장
            if (WbFile.FileSave(strFileName, bytePic) == false)
                return false;

            //Thread.Sleep(50);
            //2. 수신된 정보를 클라이언트에게 전송
            BroadcastMessage(strFileName, bytePic);

            return true;
        }

        public void Join()
        {
            
            //1. IFileCallback 객체 생성 
            callback = OperationContext.Current.GetCallbackChannel<IFileCallback>();

            //2. delegate생성 및 List에 추가 
            MyFile = new FileSend(UserHandler);
            ClientList += MyFile;
        }
        #endregion


        private void BroadcastMessage(string strFileName, byte[] bytePic)
        {
            //1대 다 통신
            //비동기로 UserHandler 함수 호출
            if (ClientList != null)
            {
                foreach (FileSend handler in ClientList.GetInvocationList())
                {
                    //if( handler != MyFile)      //<== 자신 제외
                    handler.BeginInvoke(strFileName, bytePic, new AsyncCallback(EndAsync), null);
                    Console.WriteLine("파일 보내기");
                }
            }
        }

        //클라이언트에 파일 보내기
        private void UserHandler(string filename, byte[] data)
        {
            try
            {
                callback.SendFile(filename, data);
            }
            catch//에러가 발생했을 경우           
            {
                ClientList -= MyFile;
                Console.WriteLine("파일 보내기 에러");
            }
        }

        //비동기 결과 호출[기능은 없음]
        private void EndAsync(IAsyncResult ar)
        {
            FileSend d = null;
            try
            {
                System.Runtime.Remoting.Messaging.AsyncResult asres = (System.Runtime.Remoting.Messaging.AsyncResult)ar;
                d = ((FileSend)asres.AsyncDelegate);
                d.EndInvoke(ar);
                Console.WriteLine("비동기 파일 전송");
            }
            catch
            {
                ClientList -= d;
            }
        }

        
    }
}
