namespace SpaceLander
{
    internal class ViewManager : IInitialize
    {
        private ShipView _shipView;
        private CrashEffectView _crashEffectView;
        private IMoveViewModel _moveViewModel;
        private FuelView _fuelView;
        private EndGameMessageView _endGameMessageView;
        private StartButtonView _startButtonView;
        private ExitButtonView _exitButtonView;
        private TitleView _titleView;
        private IFuelViewModel _fuelViewModel;
        private IGameManager _gameManager;
        private ICrashAssessmentViewModel _crashAssessmentViewModel;
        private ILandingAssessmentViewModel _landingAssessmentViewModel;
        
        public ViewManager(ShipView shipView, 
            CrashEffectView crashEffectView, 
            IMoveViewModel moveViewModel,
            FuelView fuelView,
            EndGameMessageView endGameMessageView,
            StartButtonView startButtonView,
            ExitButtonView exitButtonView,
            TitleView titleView,
            IHitListener hitListener,
            IFuelViewModel fuelViewModel,
            IGameManager gameManager)
        {
            _shipView = shipView;
            _crashEffectView = crashEffectView;
            _moveViewModel = moveViewModel;
            _fuelView = fuelView;
            _endGameMessageView = endGameMessageView;
            _startButtonView = startButtonView;
            _exitButtonView = exitButtonView;
            _titleView = titleView;
            _fuelViewModel = fuelViewModel;
            _crashAssessmentViewModel = hitListener.CrashAssessment;
            _landingAssessmentViewModel = hitListener.LandingAssessment;
            _gameManager = gameManager;

        }

        public void Initialize()
        {
            _shipView.InitializeView(_moveViewModel);
            _fuelView.InitializeView(_fuelViewModel);
            _crashEffectView.InitializeView(_crashAssessmentViewModel);
            _titleView.InitializeView(_crashAssessmentViewModel, _landingAssessmentViewModel);
            _startButtonView.InitializeView(_crashAssessmentViewModel, _landingAssessmentViewModel, _gameManager);
            _exitButtonView.InitializeView(_crashAssessmentViewModel, _landingAssessmentViewModel, _gameManager);
            _endGameMessageView.InitializeView(_crashAssessmentViewModel, _landingAssessmentViewModel);
        }
    }
}
