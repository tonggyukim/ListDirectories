using System;
using System.IO;

namespace fileUtility
{
    public class SolutionClass
    {
        public void ListDirectory(string path, int level)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            string tabbing = "\t\t\t" + new string('\t', level);
            Console.WriteLine($"{tabbing}{path}");

            EnumerationOptions options = new EnumerationOptions();
            options.ReturnSpecialDirectories = true;
            options.AttributesToSkip = FileAttributes.System;
            //DateTime creationdate = new DateTime(path.toString);


            //foreach (FileSystemInfo fileInfo in di.EnumerateFileSystemInfos("*",SearchOption.AllDirectories))
            foreach (FileSystemInfo fileInfo in di.EnumerateFileSystemInfos("*", options))
                {
                //abcderfg & 00010000 = 000d0000
                //Console.WriteLine($"{Convert.ToString((uint)fileInfo.Attributes, 2)}");
                if ((fileInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //Console.WriteLine($"before calling level is {level}");
                    if (fileInfo.Name == "." || fileInfo.Name == "..")
                    {
                        Console.WriteLine($"\t{tabbing}{(fileInfo.CreationTime).ToString("MMM dd HH:mm")} {fileInfo.Name}");
                    }
                    else 
                    {
                        ListDirectory(fileInfo.FullName, level + 1);
                    }

                    
                    //Console.WriteLine($"current level is {level}");
                }
                else
                {
                    FileInfo info = new FileInfo(fileInfo.FullName);
                    long length = info.Length;
                    Console.WriteLine($"\t{tabbing}{string.Format("{0,8}",length)} {(fileInfo.CreationTime).ToString("MMM dd HH:mm")} {fileInfo.Name}");
                    string user = System.IO.File.GetAccessControl(fileInfo.FullName).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();
                }
                //Console.WriteLine($"{fileInfo.FullName}");
            }
        }
    }
}
