using System;
using System.IO;
using fileUtility;

namespace FileDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            SolutionClass solution = new SolutionClass();
            solution.ListDirectory(path, 0);
        }
    }
}
