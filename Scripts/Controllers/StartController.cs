using Ship;
using SpaceLander.View;
using UnityEngine;
using UnityEngine.UI;
using UserInput;
using ViewModel;

namespace SpaceLander
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Data.Data _data;

        [SerializeField] private FuelView _fuelView;
        [SerializeField] private GameObject _messageView;
        [SerializeField] private Text _titleView;
        [SerializeField] private Button _startBtnView;
        [SerializeField] private Button _exitBtnView;

        private Controllers _controllers;

        private ShipFactory _ship;

        private void Awake()
        {
            var ship = new ShipModel(new ShipFactory(_data.ShipData.ShipPrefab));
            var inputInitialize = new InputInitialize();
            var camera = new CameraController.CameraController(ship.ShipTransform(), _data.CameraData);
            var stage = new StageBuildController(_data.StageData);

            var shipModelFactory = new ShipDetailsModelFactory(ship.Ship, _data.ShipData);

            var fuelViewModel = new FuelViewModel(shipModelFactory.FuelModel);
            var moveController = new MoveController(fuelViewModel, shipModelFactory.ForceModel,
                ship.ShipTransform(), inputInitialize.GetMoveInput(), ship.ShipAudioSource);

            _controllers = new Controllers();
            _controllers.Add(stage);
            _controllers.Add(camera);
            _controllers.Add(new InputController(inputInitialize.GetMoveInput(), inputInitialize.GetPauseInput(),
                inputInitialize.GetExitInput()));
            _controllers.Add(moveController);

            _fuelView.Initialize(fuelViewModel);
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
