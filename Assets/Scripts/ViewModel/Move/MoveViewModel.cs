using System;
using UnityEngine;
using UserInput;

namespace SpaceLander
{
    internal class MoveViewModel : IExecute, ICleanup, IMoveViewModel
    {
        public event Action<Vector3> OnMovementChange;
        public event Action<Vector3> OnRotateChange;
        public event Action<Vector3> OnStopMove;
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;
        private readonly IFuelViewModel _fuelViewModel;
        private readonly IForceModel _forceModel;
        private readonly Transform _ship;
        private float _horizontal;
        private float _vertical;
        private bool _isMoveUp;

        public MoveViewModel(IFuelViewModel fuelViewModel, IForceModel forceModel, Transform ship,
            (IUserInputProxy horizontal, IUserInputProxy vertical) input)
        {
            _ship = ship;
            _forceModel = forceModel;
            _fuelViewModel = fuelViewModel;
            _horizontalInputProxy = input.horizontal;
            _verticalInputProxy = input.vertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            _isMoveUp = false;
        }

        public AudioClip ThrusterSound => _forceModel.ThrusterSound;
        private void VerticalOnAxisOnChange(float value) => _vertical = value;

        private void HorizontalOnAxisOnChange(float value) => _horizontal = value;

        public void Execute(float deltaTime)
        {
            CheckVertical(deltaTime);
            CheckHorizontal(deltaTime);
        }

        private void CheckVertical(float deltaTime)
        {
            if (_vertical > 0 && _fuelViewModel.HasFuel)
            {
                MoveUp(deltaTime);
            }
            else
            {
                if (_isMoveUp != true) return;
                OnStopMove?.Invoke(Vector3.zero);
                _isMoveUp = false;
            }
        }

        private void CheckHorizontal(float deltaTime)
        {
            if (_horizontal > 0 && _fuelViewModel.HasFuel)
            {
                RotateLeft(deltaTime);
            }
            else if (_horizontal < 0 && _fuelViewModel.HasFuel)
            {
                RotateRight(deltaTime);
            }
            else
            {
                OnRotateChange?.Invoke(Vector3.zero);
            }
        }

        private void MoveUp(float deltaTime)
        {
            _fuelViewModel.ConsumeFuelToRise(deltaTime);
            var vector = _ship.up * _forceModel.ForceRate;
            if (_isMoveUp == false)
            {
                OnMovementChange?.Invoke(vector);
                _isMoveUp = true;
            }
        }

        private void RotateLeft(float deltaTime)
        {
            _fuelViewModel.ConsumeFuelOnTorque(deltaTime);
            var vector = _forceModel.TorqueRate * Vector3.back;
            OnRotateChange?.Invoke(vector);
        }

        private void RotateRight(float deltaTime)
        {
            _fuelViewModel.ConsumeFuelOnTorque(deltaTime);
            var vector = _forceModel.TorqueRate * Vector3.forward;
            OnRotateChange?.Invoke(vector);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
