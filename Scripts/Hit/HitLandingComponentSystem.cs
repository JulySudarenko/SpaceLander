using System;
using UnityEngine;

namespace SpaceLander
{
    public class HitLandingComponentSystem : MonoBehaviour
    {
        public Action<GameObject, GameObject, float> OnHit;

        private void OnCollisionEnter(Collision other)
        {
            OnHit?.Invoke(gameObject, other.gameObject, other.relativeVelocity.magnitude);
        }
    }
}
