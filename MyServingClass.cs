using System;
using System.Collections.Generic;


namespace Lab9
{
    class MyServingClass
    {
        public static void Exiting(List<IVisitor> luckyOnes)
        {
            ColoredWriting("\n ***Список тех, кому посчастливилось попасть в ИКИТ:***", ConsoleColor.Green);
            foreach (IVisitor p in luckyOnes)
            {
                ColoredWriting($"{p.ToString()}", ConsoleColor.Green);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n*** Нажмите любую клавишу, чтобы выйти из программы... ***\n");
            Environment.Exit(0);
        }

        public static void ColoredWriting(string text, ConsoleColor color)
        {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = prevColor;
        }
    }
}
