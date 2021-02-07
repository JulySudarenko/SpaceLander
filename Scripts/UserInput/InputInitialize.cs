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

//internal sealed class  


// constForce.force = transform.up * forceRate;
// fuel += fuelRate * Time.deltaTime;
// gameUI.UpdateFuelText(fuel);

// else
// {
//     constForce.force = Vector3.zero;
// }
// if (Input.GetKey(KeyCode.LeftArrow))
// {
// constForce.torque = torqueRate * Vector3.forward;
// fuel += (fuelRate / 10f) * Time.deltaTime;
// gameUI.UpdateFuelText(fuel);
// }
// else if (Input.GetKey(KeyCode.RightArrow))
// {
// constForce.torque = torqueRate * Vector3.back;
// fuel += (fuelRate / 10f) * Time.deltaTime;
// gameUI.UpdateFuelText(fuel);
// }
// else
// {
// constForce.torque = Vector3.zero;
// }
//
// if (Input.GetKeyDown(KeyCode.UpArrow))
// {
// thruster.Play();
// audioSource.clip = thrusterSound;
// audioSource.Play();
// }
// else if (Input.GetKeyUp(KeyCode.UpArrow))
// {
// thruster.Stop();
// audioSource.Stop();
// if (audioSource.clip == thrusterSound)
// {
//     audioSource.Stop();
// }
// }
