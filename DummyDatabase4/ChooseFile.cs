using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DummyDatabase4
{
    class ChooseFile
    {
        static string NameProject = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private static int MaxLength(string[] path)
        {
            int length = 0;
            for (int i = 0; i < path.Length; i++)
            {
                length = Math.Max(length, (NameProject + path[i]+"csv").Length);
            }
            return length;
        }
        private static void EndLine(int lengthOfLine, int Y)
        {
            //Метод создает линию для разделения данных

            Console.SetCursorPosition(0, Y);

            for (int i = 0; i < (lengthOfLine + 5); i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }
        private static void WriteTable(string[] path)
        {
            int Y = 0;
            int length = MaxLength(path);

            for (int i = 0; i < path.Length; i++)
            {
                EndLine(length, Y);
                Y++;
                int X = 0;
                Console.SetCursorPosition(X, Y);
                Console.Write($"|{NameProject + path[i]+"csv"}");
                X = X + length + 1;
                Console.SetCursorPosition(X, Y);
                Console.Write("|  |");
                Y++;
            }
            EndLine(length, Y);
        }
        private static int Moover(int length, int height)
        {
            int X = length + 3;
            int Y = 1;
            Console.SetCursorPosition(X, Y);
            int answer = 0;
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.UpArrow)
                {
                    if (Y - 2 >= 1) Y -= 2;
                    else Y = height-2;
                }
                if (consoleKeyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (Y + 2 < height) Y += 2;
                    else Y = 1;
                }
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                {
                    answer = Y / 2;
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.SetCursorPosition(X, Y);
                    Console.Write(" ");
                }
                Console.SetCursorPosition(X, Y);
            }

            return answer;
        }

        public static string WriteTableWithFile(string[] path)
        {
            WriteTable(path);
            Console.SetCursorPosition(0, 0);
            return path[Moover(MaxLength(path), path.Length * 2 + 1)];

        }
    }
}
