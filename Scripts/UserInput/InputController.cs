using SpaceLander;

namespace UserInput
{
    internal class InputController : IFixedExecute
    {
        private readonly IUserInputProxy _inputVertical;
        private readonly IUserInputProxy _inputHorizontal;
        private readonly IUserInputProxy _inputPause;
        private readonly IUserInputProxy _inputExit;

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            IUserInputProxy inputPause, IUserInputProxy inputExit)
        {
            _inputVertical = input.inputVertical;
            _inputHorizontal = input.inputHorizontal;
            _inputPause = inputPause;
            _inputExit = inputExit;
        }
        
        public void FixedExecute(float deltaTime)
        {
            _inputVertical.GetAxis();
            _inputHorizontal.GetAxis();
            _inputPause.GetAxis();
            _inputExit.GetAxis();
        }
    }
}
