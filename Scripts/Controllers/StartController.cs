using Data;
using Ship;
using UnityEngine;


namespace SpaceLander
{
    public class StartController : MonoBehaviour
    {
        [SerializeField] private Data.Data Data;
        [SerializeField] private UIData UIData;

        private Controllers _controllers;

        private ShipFactory _ship;


        private void Awake()
        {
            var ship = new ShipInitialize(new ShipFactory(Data.ShipData.ShipPrefab));
            var camera = new CameraController(ship.ShipTransform(), Data.CameraData);
            var stage = new StageBuildController(Data.StageData);


            _controllers = new Controllers();
            _controllers.Add(stage);
            _controllers.Add(camera);

        }

        private void Start()
        {
            //MoonSurface
            //Physics.gravity = new Vector3(0, -1.628F, 0);
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
