using System;
using UnityEngine;

namespace SpaceLander
{
    internal sealed class HitShipSystem : MonoBehaviour
    {
        public Action<HitState, GameObject> OnHit;

        private void OnTriggerEnter(Collider other)
        {
            OnHit?.Invoke(HitState.Enter, other.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            OnHit?.Invoke(HitState.Stay, other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            OnHit?.Invoke(HitState.Exit, other.gameObject);
        }
    }
}
