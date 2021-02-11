namespace UserInput
{
    internal class InputInitialize
    {
        private readonly IUserInputProxy _pcInputVertical;
        private readonly IUserInputProxy _pcInputHorizontal;
        private readonly IUserInputProxy _pcInputPause;
        private readonly IUserInputProxy _pcInputExit;

        public InputInitialize()
        {
            _pcInputVertical = new PCInputVertical();
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputPause = new PCInputPause();
            _pcInputExit = new PCInputExit();
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetMoveInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) result = (_pcInputHorizontal,
                _pcInputVertical);
            return result;
        }

        public IUserInputProxy GetPauseInput()
        {
            return _pcInputPause;
        }

        public IUserInputProxy GetExitInput()
        {
            return _pcInputExit;
        }
    }
}

