namespace Lab9
{
    class Squirrel : Animal, IVisitor
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name} (белка)";
        }
    }
}
