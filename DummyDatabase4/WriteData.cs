using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    public class WriterData
    {

        private static int Lenght(Dictionary<string, int> MaxLengthOfColumn)
        {
            int length = 0;

            foreach (var key in MaxLengthOfColumn)
            {
                length += key.Value;
            }

            length += MaxLengthOfColumn.Count + 1;

            return length;
        }
        public static int WriteData(Schema schema, Dictionary<string, int> MaxLengthOfColumn, int Y)
        {
            int length = Lenght(MaxLengthOfColumn);

            EndLine(length, Y);
            Y++;
            CreateHeadLine(MaxLengthOfColumn, Y);
            Y++;
            EndLine(length, Y);
            Y++;
            
            for (int i = 0; i < schema.Data.First().Value.Count; i++)
            {
                CreateLine(schema.Data, MaxLengthOfColumn, Y ,i);
                Y++;
                EndLine(length, Y);
                Y++;
            }
            return Y;
        }
        private static void CreateHeadLine(Dictionary<string, int> MaxLengthOfColumn, int Y)
        {
            int X = 0;
            Console.SetCursorPosition(X, Y);

            foreach (var key in MaxLengthOfColumn)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write($"|{key.Key}");
                X = X + key.Value + 1;
            }
            Console.Write("|");
            Console.WriteLine();
        }
        private static void CreateLine(Dictionary<string, List<object>> Data, Dictionary<string, int> MaxLengthOfColumn, int Y , int i)
        {
            //Метод делает "линию" из данных переданных для вывода

            int X = 0;

            foreach (var element in Data.Keys)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write($"|{Data[element][i]}");
                X = X + MaxLengthOfColumn[element] + 1;
            }
            Console.SetCursorPosition(X, Y);
            Console.Write("|");
        }
        private static void EndLine(int lengthOfLine, int Y)
        {
            //Метод создает линию для разделения данных

            Console.SetCursorPosition(0, Y);

            for (int i = 0; i < (lengthOfLine); i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }
    }
}