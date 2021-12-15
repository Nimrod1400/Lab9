using System;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Checkpoint checkpoint = new Checkpoint();

            int? masks = null;
            int? desinfectors = null;
            int? amountOfVisitors = null;

            Console.Write($"Хотите ли вы ввести кол-во людей, желающих войти, кол-во доз антисептика, " +
                $"кол-во масок самостоятельно? [y, n] ");
            var answer = Console.ReadKey();
            Console.WriteLine();

            if (answer.Key == ConsoleKey.Y)
            {
                Console.Write("Введите кол-во масок: ");
                masks = int.Parse(Console.ReadLine());
                Console.Write("Введите кол-во доз антисептика: ");
                desinfectors = int.Parse(Console.ReadLine());
                Console.Write("Введите кол-во желающих войти: ");
                amountOfVisitors = int.Parse(Console.ReadLine());
            }

            if (masks != null && desinfectors != null)
            {
                checkpoint.LeftMasks = (uint)masks;
                checkpoint.LeftDosesOfDes = (uint)desinfectors;
            }

            if (amountOfVisitors == null)
            {
                amountOfVisitors = (int)(6 + MyRandomGen.RandomAmount(0, 5)); // рандомно от 6 до 10
            }
            
            for (byte i = 0; i < amountOfVisitors; i++)
            {
                checkpoint.VisitorsWantIn.Add(MyRandomGen.GenerateVisitor());
            }
            Console.WriteLine();

            for (byte i = 0; i < amountOfVisitors; i++)
            {
                checkpoint.Check();
                Console.ReadKey();
            }
        }
    }
}
