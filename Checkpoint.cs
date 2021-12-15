using System;
using System.Collections.Generic;


namespace Lab9
{
    class Checkpoint
    {
        public List<IVisitor> VisitorsWantIn { get; set; } = new List<IVisitor>();
        private List<IVisitor> VisitorsAreIn { get; set; } = new List<IVisitor>();
        public uint LeftMasks { get; set; } = MyRandomGen.RandomAmount(5, 10);
        public uint LeftDosesOfDes { get; set; } = MyRandomGen.RandomAmount(7, 15);

        public void Check()
        {
            ushort visitoirIndex = (ushort)(VisitorsWantIn.Count - 1);
            IVisitor visitor = VisitorsWantIn[visitoirIndex];

            if (visitor is IQRCode &&  visitor is ICanPutOnMask && visitor is ICanDesinfectHand)
            {
                ControlNormies();
            }
            else if (visitor is Animal)
            {
                MyServingClass.ColoredWriting($"{visitor.ToString()} предпринял попытку пройти КПП. " +
                    $"В доступе отказано. Причина: посетитель является животным.\n", ConsoleColor.Red);
                VisitorsWantIn.RemoveAt(visitoirIndex);
            }
            else
            {
                MyServingClass.ColoredWriting("В ИКИТ пыталось пройти что-то, что не может иметь QR-код, " +
                    "носить маску и дезинфицировать конечности. В доступе было отказано.\n", ConsoleColor.Red);
                VisitorsWantIn.RemoveAt(visitoirIndex);
            }
            
            // метод, созданный, чтобы упростить цепочку ифов
            void ControlNormies()
            {
                bool hasMask = (visitor as ICanPutOnMask).IsHasMask;
                bool hasQR = (visitor as IQRCode).IsHasQR;

                // я старался упростить это изо всех сил, много работал над этим, получилось вот
                if (hasMask && hasQR)
                {
                    MyServingClass.ColoredWriting($"{visitor.ToString()} имеет собственную маску.",
                        ConsoleColor.Green);

                }
                else if (LeftMasks > 0 && hasQR)
                {
                    LeftMasks--;
                    MyServingClass.ColoredWriting($"{visitor.ToString()} не имеет маски, поэтому " +
                        $"пришлось её выдать. Осталось масок: {LeftMasks}", ConsoleColor.Yellow);
                }
                else if (LeftMasks == 0 && hasQR && !hasMask)
                {
                    MyServingClass.ColoredWriting($"{visitor.ToString()} не имеет маски, " +
                        $"и на складе их нет. В доступе было отказано.\n", ConsoleColor.Red);
                    VisitorsWantIn.RemoveAt(visitoirIndex);
                }                
                else if (!hasQR)
                {
                    MyServingClass.ColoredWriting($"{visitor.ToString()} не имеет QR-кода. В доступе было отказано.\n",
                        ConsoleColor.Red);
                    VisitorsWantIn.RemoveAt(visitoirIndex);
                }

                // мажем руки посетителя, если тот проходит по всем признакам
                if (hasQR && !(LeftMasks == 0 && hasQR && !hasMask))
                {
                    LeftDosesOfDes--;
                    Console.WriteLine($"{visitor.ToString()} обработал руки антисептиком. " +
                        $"Доз антисептика осталось: {LeftDosesOfDes}.");
                    VisitorsWantIn.RemoveAt(visitoirIndex);
                    VisitorsAreIn.Add(visitor);
                    MyServingClass.ColoredWriting($"{visitor.ToString()} прошёл КПП и теперь находится в ИКИТ'е\n",
                        ConsoleColor.Green);
                }
            }

            

            if (LeftDosesOfDes == 0 && VisitorsWantIn.Count != 0)
            {
                MyServingClass.ColoredWriting($"На складе не осталось антисептика. Желающих войти осталось: " +
                    $"{VisitorsWantIn.Count}", ConsoleColor.Red);
                MyServingClass.Exiting(VisitorsAreIn);
            }
            else if (VisitorsWantIn.Count == 0)
            {
                MyServingClass.ColoredWriting($"Мы приняли всех, кто хочет и может войти. На складе осталось " +
                    $"{LeftMasks} маск и {LeftDosesOfDes} доз антисептика.", ConsoleColor.Green);
                MyServingClass.Exiting(VisitorsAreIn);
            }
            
        }
    }
}
