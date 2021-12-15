namespace Lab9
{
    class Dog : Animal, IVisitor, ICanPutOnMask
    {
        public string Name { get; set; }
        public bool IsHasMask { get; set; }

        public override string ToString()
        {
            return $"{Name} (пёс)";
        }
    }
}
