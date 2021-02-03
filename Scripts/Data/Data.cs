using UnityEngine;
using static SpaceLander.Extentions;

namespace Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data", order = 0)]
    public class Data : ScriptableObject
    {
        [SerializeField] private string _cameraDataPath;
        [SerializeField] private string _shipDataPath;
        [SerializeField] private string _stageDataPath;
        private CameraData _cameraData;
        private ShipData _shipData;
        private StageData _stageData;

        public CameraData CameraData
        {
            get
            {
                if (_cameraData == null)
                {
                    _cameraData = Load<CameraData>("Data/" + _cameraDataPath);
                }

                return _cameraData;
            }
        }
        
        public ShipData ShipData
        {
            get
            {
                if (_shipData == null)
                {
                    _shipData = Load<ShipData>("Data/" + _shipDataPath);
                }

                return _shipData;
            }
        }
        
        public StageData StageData
        {
            get
            {
                if (_stageData == null)
                {
                    _stageData = Load<StageData>("Data/" + _stageDataPath);
                }

                return _stageData;
            }
        }
    }
}
