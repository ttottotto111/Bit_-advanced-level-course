using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace _1124PictureService
{
    [ServiceContract]
    interface Trans
    {
        [OperationContract]
        string TransText(string msg);
    }
}
