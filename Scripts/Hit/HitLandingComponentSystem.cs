using System;
using UnityEngine;

namespace SpaceLander
{
    public class HitLandingComponentSystem : MonoBehaviour
    {
        public Action<GameObject> OnHit;

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Ups");
            OnHit?.Invoke(other.gameObject);
        }
    }
}
