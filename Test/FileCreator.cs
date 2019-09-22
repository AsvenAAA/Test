using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Test
{
    class FileCreator
    {
        public void WriteToFile()
        {
            using (StreamWriter writeToFile = new StreamWriter(@"C:\Users\Asven\Desktop\Mytest.txt"))
            {
                foreach (Match searchValue in TextFinder.GetValue())
                {
                    writeToFile.Write(searchValue.Value);
                }
                writeToFile.Close();
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
