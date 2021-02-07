using SpaceLander.Model;
using UnityEngine;
using UserInput;

namespace SpaceLander
{
    internal class MoveController : IFixedExecute, ICleanup
    {
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;
        private readonly IFuelViewModel _fuelViewModel;
        private readonly IForceModel _forceModel;
        private readonly Transform _ship;
        private readonly AudioSource _audio;
        private float _horizontal;
        private float _vertical;

        public MoveController(IFuelViewModel fuelViewModel, IForceModel forceModel, Transform ship,
            (IUserInputProxy horizontal, IUserInputProxy vertical) input, AudioSource audio)
        {
            _ship = ship;
            _audio = audio;
            _forceModel = forceModel;
            _fuelViewModel = fuelViewModel;
            _horizontalInputProxy = input.horizontal;
            _verticalInputProxy = input.vertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        public void FixedExecute(float deltaTime)
        {
            if (_fuelViewModel.HasFuel)
            {
                if (_vertical > 0)
                {
                    //move
                    _forceModel.ShipConstantForce.force = _ship.transform.up * _forceModel.ForceRate;
                    //fuel
                    _fuelViewModel.ConsumeFuelToRise(deltaTime);
                    //particle
                    _forceModel.Thruster.Play();
                    //audio
                    _audio.clip = _forceModel.ThrusterSound;
                    _audio.Play();
                }
                else
                {
                    _forceModel.ShipConstantForce.force = Vector3.zero;
                    _forceModel.Thruster.Stop();

                    if (_audio.clip == _forceModel.ThrusterSound)
                    {
                        _audio.Stop();
                    }
                }

                if (_horizontal > 0)
                {
                    _forceModel.ShipConstantForce.torque = _forceModel.TorqueRate * Vector3.back;
                    _fuelViewModel.ConsumeFuelOnTorque(deltaTime);
                }

                else if (_horizontal < 0)
                {
                    _forceModel.ShipConstantForce.torque = _forceModel.TorqueRate * Vector3.forward;
                    _fuelViewModel.ConsumeFuelOnTorque(deltaTime);
                }
                else
                {
                    _forceModel.ShipConstantForce.torque = Vector3.zero;
                }
            }
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
