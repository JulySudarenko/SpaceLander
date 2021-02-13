using UserInput;

namespace SpaceLander
{
    internal class InputController : IFixedExecute
    {
        private readonly IUserInputProxy _inputVertical;
        private readonly IUserInputProxy _inputHorizontal;

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input)
        {
            _inputVertical = input.inputVertical;
            _inputHorizontal = input.inputHorizontal;
        }
        
        public void FixedExecute(float deltaTime)
        {
            _inputVertical.GetAxis();
            _inputHorizontal.GetAxis();
        }
    }
}
