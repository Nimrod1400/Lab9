namespace Lab9
{
    class Teacher : Human, IVisitor, ICanPutOnMask, ICanDesinfectHand, IQRCode
    {
        public string Name { get; set; }
        public bool IsHasMask { get; set; }
        public bool IsHasQR { get; set; }

        public override string ToString()
        {
            return $"{Name} (учитель)";
        }
    }
}
