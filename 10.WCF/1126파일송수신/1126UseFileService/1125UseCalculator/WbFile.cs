using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _1125UseCalculator
{
    class WbFile
    {
        public static bool FileSave(string strFileName, byte[] bytePic)
        {
            try
            {
                // 주어진 이미지 파일의 이름으로 파일을 하나 만든다.
                FileStream writeFileStream = new FileStream(strFileName, FileMode.Create, FileAccess.Write);

                // 이 파일에 바이너리를 넣기 위해 BinaryWriter 객체 생성
                BinaryWriter picWriter = new BinaryWriter(writeFileStream);
                // 바이트 배열로 받은 이미지를 파일에 쓴다.
                picWriter.Write(bytePic);
                // 파일스트림을 닫는다.
                writeFileStream.Close();
                // 업로드 성공
                return true;
            }
            catch (Exception)
            {
                // 업로드 실패
                return false;
            }
        }
    }
}
