namespace Game.Module.Calculator
{
    public struct SubCalculatorMessage
    {
        public float Result { get; private set; }

        public SubCalculatorMessage(float result)
        {
            Result = result;
        }
    }

}
