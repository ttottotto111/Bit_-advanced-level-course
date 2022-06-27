using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace _1124PictureService
{
    [DataContract]
    class TransMessage
    {
        [DataMember]
        public string Transmsg { get; set; }
    }
}
