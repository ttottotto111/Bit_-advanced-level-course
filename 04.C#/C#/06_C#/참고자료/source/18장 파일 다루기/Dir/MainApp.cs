using System;
using System.Linq;
using System.IO;

namespace Dir
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string directory = "c:\\";
            //if (args.Length < 1)
            //    directory = ".";
            //else
            //    directory = args[0];

            Console.WriteLine("{0} directory Info", directory);
            Console.WriteLine("- Directories :");

            
             //1. 해당 Dir에서 폴더명들을 획득 
            
            string [] dir1 = Directory.GetDirectories(directory);
            foreach (string s in dir1)
            {
                DirectoryInfo info = new DirectoryInfo(s);
                Console.WriteLine("{0} : {1}", info.Name, info.Attributes);
            }             

            /*
            var directories = (from dir in Directory.GetDirectories(directory)
                         let info = new DirectoryInfo(dir)
                         select new
                         {
                             Name = info.Name,
                             Attributes = info.Attributes
                         }).ToList();

            foreach (var d in directories)
                Console.WriteLine("{0} : {1}", d.Name, d.Attributes);
            */

            string[] dir2 = Directory.GetFiles(directory);
            foreach (string s in dir2)
            {
                FileInfo info = new FileInfo(s);
                Console.WriteLine("{0} : {1} : {2}", info.Name, info.Length, info.Attributes);
            } 
            /*
            Console.WriteLine("- Files :");
            var files = (from file in Directory.GetFiles(directory)
                         let info = new FileInfo(file)
                              select new
                              {
                                  Name = info.Name,
                                  FileSize = info.Length,
                                  Attributes = info.Attributes
                              }).ToList();
            foreach (var f in files)
                Console.WriteLine("{0} : {1}, {2}",
                    f.Name, f.FileSize, f.Attributes);
             */
        }
    }
}
