using System;
using Assistants;
using UnityEngine;

namespace UserInput
{
    internal sealed class PCInputPause : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) { };

        public void GetAxis()
        {
            AxisOnChange?.Invoke(Input.GetAxis(AxisManager.PAUSE));
        }
    }
}
