namespace Lab9
{
    class Dove : Animal, IVisitor
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name} (голубь)";
        }
    }
}
