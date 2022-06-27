using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace _1007실습
{
    class FileExample
    {
        static String filename1 = "sample.txt";
        static String filename2 = "sample1.txt";

        #region byte[] 기반 IO 수행
        public static void Write1()
        {
            List<Account> acclist = new List<Account>();
            acclist.Add(new Account(1000, "홍길동", 1000));
            acclist.Add(new FaithAccount(2000, "이길동", 1000));
            acclist.Add(new ContriAccount(3000, "고길동", 1000));

            // 1) 파일 스트림 생성
            Stream outStream = new FileStream(filename1, FileMode.Create);

            // 2) 객체의 정보를 문자열로 변환 -> 바이트배열로 변환
            String str = String.Empty;
            foreach(Account acc in acclist)
            {
                str += acc.Id + "#";
                str += acc.Name + "#";
                str += acc.Balance + "#";
                str += acc.MakeTime + "@";
            }
            Console.WriteLine("1. 객체를 문자열로 변환 : \n" + str);
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            Console.WriteLine("\n2. 문자열을 바이트배열로 변환 : \n" + StrByte.Length);

            // 3) 변환한 byte 배열을 파일 스트림을 통해 파일에 기록
            outStream.Write(StrByte, 0, StrByte.Length);

            // 4) 파일 스트림 닫기
            outStream.Close();
        }

        public static void Read1()
        {          
            
            // 1) 파일 스트림 생성
            Stream inStream = new FileStream(filename1, FileMode.Open);

            // 2) rBytes의 길이만큼(8바이트) 데이터를 읽어 rBytes에 저장
            byte[] rBytes = new byte[256];
            inStream.Read(rBytes, 0, rBytes.Length);

            // 3) byte[] -> string
            string str = Encoding.UTF8.GetString(rBytes);
            Console.WriteLine(str);
            //객체화
            List<Account> acclist = new List<Account>();
            string[] split1 = str.Split('@');
            for (int i = 0; i < split1.Length-1; i++)
            {
                string[] split2 = split1[i].Split('#');
                Account acc = new Account(int.Parse(split2[0]),
                    split2[1], int.Parse(split2[2]));
                acc.MakeTime = DateTime.Parse(split2[3]);

                acclist.Add(acc);
            }
            // 4) 파일 스트림 닫기
            inStream.Close();

            PrintAccount(acclist);
        }

        public static void PrintAccount(List<Account> list)
        {
            foreach (Account acc in list)
            {
                Console.WriteLine(acc);
            }
                
        }
        #endregion

        #region 직렬화

        public static void Write2(Dictionary<int, Account> accounts)
        {
            Stream ws = new FileStream(filename2, FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();            
            serializer.Serialize(ws, accounts);
            ws.Close();
        }

        public static void Read2(ref Dictionary<int, Account> accounts)
        {
            try
            {
                Stream rs = new FileStream(filename2, FileMode.Open);
                BinaryFormatter deserializer = new BinaryFormatter();

                accounts = (Dictionary<int, Account>)deserializer.Deserialize(rs);
                rs.Close();
            }
            catch
            {

            }
        }

        #endregion
    }
}
