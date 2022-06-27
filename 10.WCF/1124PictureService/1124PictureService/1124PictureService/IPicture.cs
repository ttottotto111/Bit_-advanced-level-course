using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace _1124PictureService
{
    [ServiceContract]
    interface IPicture
    {
        [OperationContract]
        byte[] GetPicture(string strFileName);

        [OperationContract]
        string[] GetPictureList();

        [OperationContract]
        bool UploadPicutre(string strFileName, byte[] bytePic);
    }
}
