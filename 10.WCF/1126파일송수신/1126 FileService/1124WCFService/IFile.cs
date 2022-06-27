using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace _1124WCFService
{
    //서비스 계약 처리 
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract =typeof(IFileCallback))]
    interface IFile
    {
        [OperationContract(IsOneWay = true, IsInitiating = true, IsTerminating = false)]
        void Join();

        [OperationContract(IsInitiating =false, IsTerminating = false)]
        bool UploadFile(string strFileName, byte[] bytePic);       
    }

    public interface IFileCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendFile(string strFileName, byte[] bytePic);
    }
}
