using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace LinqIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("-----------");
            ShowLargeFilesWitLinq(path);
        }

        private static void ShowLargeFilesWitLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            var anotherQuerySyntax = from file in new DirectoryInfo(path).GetFiles()
                                     orderby file.Length descending
                                     select file;

            foreach (var file in anotherQuerySyntax.Take(5))
                Console.WriteLine($"{file.Name,20} : {file.Length,10:N0}");
            foreach (var file in query)
                Console.WriteLine($"{file.Name,20} : {file.Length,10:N0}");
            
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for(int i=0;i<5;++i)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name, 20} : {file.Length, 10:N0}");
            }
        }
        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare([AllowNull] FileInfo x, [AllowNull] FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
