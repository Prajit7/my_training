using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace SampleFrameWorkWeek2
{
    class ExFileIO
    {
        static void Main(string[] args)
        {


            //readFile();
            writeFileEx();

      
            
        }

        private static void writeFileEx()
        {
            string desktopFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + "SampleText.txt";
            var content = "Hello My name is Prajit";
            File.WriteAllText(desktopFile, content);

            File.AppendAllText(desktopFile, ",I'm from Murdeshwar and settled in Gokak");

        }

        private static void readFile()
        {
            string fileName = "../../ExFileIo.cs";
            if (!File.Exists(fileName))
            {
                Console.WriteLine("File not Found");
            }
            else
            {
                var contents = File.ReadAllText(fileName);
                Console.WriteLine(contents);
            }
        }
    }
}
