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
        public static void WriteData(Schema schema, Dictionary<string, int> MaxLengthOfColumn , ref int Y)
        {
            int length = Lenght(MaxLengthOfColumn);

            EndLine(length, Y);
            Y++;
            CreateHeadLine(MaxLengthOfColumn, Y);
            Y++;
            EndLine(length, Y);
            Y++;
            for (int i = 0; i < schema.Columns.Count; i++)
            {
                CreateLine(schema.Columns[i], MaxLengthOfColumn, Y);
                Y++;
                EndLine(length, Y);
                Y++;
            }
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
        private static void CreateLine(Column column, Dictionary<string, int> MaxLengthOfColumn, int Y)
        {
            //Метод делает "линию" из данных переданных для вывода

            int X = 0;

            foreach (var element in column.Line)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write($"|{element.Value.Data}");
                X = X + MaxLengthOfColumn[element.Key] + 1;
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