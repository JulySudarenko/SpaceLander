using System;
using UnityEngine;

namespace SpaceLander
{
    public class Hit : MonoBehaviour
    {
        public Action<GameObject, GameObject> OnHit;

        private void OnCollisionEnter(Collision other)
        {
            OnHit?.Invoke(gameObject, other.gameObject);
        }
    }
}
