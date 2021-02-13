namespace SpaceLander
{
    internal class ShipDetailsModelFactory
    {
        private IFuelModel _fuelModel;
        private IForceModel _forceModel;
        private IWinModel _winModel;
        private ICrashModel _crashModel;

        public ShipDetailsModelFactory(ShipData data)
        {
            _fuelModel = new FuelModel(data);
            _forceModel = new ForceModel(data);
            _winModel = new WinModel(data);
            _crashModel = new CrashModel(data);
        }

        public IFuelModel FuelModel => _fuelModel;
        public IForceModel ForceModel => _forceModel;
        public IWinModel WinModel => _winModel;

        public ICrashModel CrashModel => _crashModel;
    }
}
