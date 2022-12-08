using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public class CsvParser
    {
        static string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static void PutData()
        {

        }

        private static void SplitData(string data) 
        {
            string[] splitted = data.Split(';');
        }
        private static void ReadFile(string path)
        {
            int countLine = 0;
            foreach(var line in File.ReadAllLines(NameProject+path)) 
            {
                if(countLine==0)
                {
                    countLine++;
                    continue;
                }



                
            }
        }
    }
}
