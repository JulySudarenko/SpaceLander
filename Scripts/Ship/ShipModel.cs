using UnityEngine;

namespace Ship
{
    internal class ShipModel
    {
        private readonly IShipFactory _shipFactory;
        public GameObject Ship { get; }
        public AudioSource ShipAudioSource { get; }

        public ShipModel(IShipFactory shipFactory)
        {
            _shipFactory = shipFactory;
            Ship = _shipFactory.CreateShip();
            if (Ship.TryGetComponent<AudioSource>(out var audio))
            {
                ShipAudioSource = audio;
            }
            
        }

        public Transform ShipTransform() => Ship.transform;

        public void GetAllParticles()
        {
            
        }

    }
}
