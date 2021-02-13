namespace UserInput
{
    internal class InputInitialize
    {
        private readonly IUserInputProxy _pcInputVertical;
        private readonly IUserInputProxy _pcInputHorizontal;

        public InputInitialize()
        {
            _pcInputVertical = new PCInputVertical();
            _pcInputHorizontal = new PCInputHorizontal();
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetMoveInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal,
                _pcInputVertical);
            return result;
        }
    }
}

