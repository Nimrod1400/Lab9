using System;
using System.Collections.Generic;


namespace Lab9
{
    static class MyRandomGen
    {
        static readonly Random r = new Random();

        public static uint RandomAmount(int min, int max)
        {
            if (max < 0 || min < 0) throw new OverflowException(message: "\n** Error: amount must be positive integer **\n");
            return (uint) r.Next(min, max);
        }

        public static IVisitor GenerateVisitor()
        {

            byte classChoice = (byte)r.Next(0, 9);

            IVisitor visitor;

            if (classChoice < 2) visitor = new Teacher();
            else if (classChoice < 4) visitor = new Student();
            else if (classChoice < 6) visitor = new Enrollee();
            else if (classChoice == 6) visitor = new Dog();
            else if (classChoice == 7) visitor = new Squirrel();
            else visitor = new Dove();

            if (visitor is Human)
            {
                visitor.Name = RandomHumanNameGenerator();
                (visitor as ICanPutOnMask).IsHasMask = RandomBool();
                (visitor as IQRCode).IsHasQR = RandomBool();
            }
            else if (visitor is Animal)
            {
                visitor.Name = RandomAnimalNameGenerator();
            }

            return visitor;
        }

        private static string RandomHumanNameGenerator()
        {
            string[] names =
                { "Михаил", "Иван", "Вадим", "Виктор", "Владимир", "Илья", "Кирилл",
            "Александр", "Алексей", "Георгий", "Григорий", "Ян", "Владислав", "Эдуард",
                "Никита", "Игорь", "Дмитрий", "Горчица" };

            byte i = (byte)r.Next(0, names.Length);
            return names[i];
        }

        private static string RandomAnimalNameGenerator()
        {
            string[] names =
                { "Толик", "Бобик", "Шарик", "Голя", "Чирикчик", 
                "Летун", "Пилот", "Ярик", "Яшка", "Эдик", "Никитун", "Уно",
                "Шатун", "Сяй" };
            byte i = (byte)r.Next(0, names.Length);
            return names[i];
        }

        private static bool RandomBool()
        {
            bool res = false;
            byte seed = (byte)r.Next(2);
            if (seed == 0) res = true;
            else res = false;
            return res;
        }
    }
}
