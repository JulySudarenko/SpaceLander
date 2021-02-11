using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    public class FuelView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private IFuelViewModel _fuelViewModel;

        public void InitializeView(IFuelViewModel fuelViewModel)
        {
            _fuelViewModel = fuelViewModel;
            _fuelViewModel.OnFuelChange += OnFuelChange;
            OnFuelChange(_fuelViewModel.FuelModel.CurrentFuel);
        }

        private void OnFuelChange(float currentFuel)
        {
            _text.text = $"Fuel\n{currentFuel}";
        }

        ~FuelView()
        {
            _fuelViewModel.OnFuelChange -= OnFuelChange;
        }

    }
}
