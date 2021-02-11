using UnityEngine;
using UserInput;

namespace SpaceLander
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Data _data;

        [SerializeField] private FuelView _fuelView;
        [SerializeField] private EndGameMessageView _messageView;
        [SerializeField] private TitleView _titleView;
        [SerializeField] private StartButtonView _startBtnView;
        [SerializeField] private ExitButtonView _exitBtnView;

        private Controllers _controllers;

        private void Awake()
        {
            var stage = new StageBuildController(_data.StageData);
            var inputInitialize = new InputInitialize();

            var ship = new ShipInitialize(new ShipFactory(_data.ShipData.ShipPrefab));
            var shipModelFactory = new ShipDetailsModelFactory(_data.ShipData);

            var hitListener =
                new HitListener(ship.ShipTransform, shipModelFactory.WinModel, shipModelFactory.CrashModel);
            var shipCrashComponent = new CrashingShipComponents(ship.ShipTransform, hitListener.CrashAssessment);

            var camera = new CameraController(ship.ShipTransform, _data.CameraData, hitListener.CrashAssessment,
                hitListener.LandingAssessment);

            var fuelViewModel = new FuelViewModel(shipModelFactory.FuelModel);
            var moveViewModel = new MoveViewModel(fuelViewModel, shipModelFactory.ForceModel,
                ship.ShipTransform, inputInitialize.GetMoveInput());

            var viewManager = new ViewManager(ship.ShipView, ship.CrashEffectView, moveViewModel,
                _fuelView, _messageView, _startBtnView, _exitBtnView, _titleView, hitListener, fuelViewModel, new GameManager());

            _controllers = new Controllers();
            _controllers.Add(stage);
            _controllers.Add(camera);
            _controllers.Add(new InputController(inputInitialize.GetMoveInput(), inputInitialize.GetPauseInput(),
                inputInitialize.GetExitInput()));
            _controllers.Add(moveViewModel);
            _controllers.Add(hitListener);
            _controllers.Add(shipCrashComponent);
            _controllers.Add(viewManager);
        }

        private void Start()
        {
            _controllers.Initialize();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
