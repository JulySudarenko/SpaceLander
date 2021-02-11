using SpaceLander;
using UnityEngine;

namespace Assistants
{
    public static class BuildAssistant
    {
        public static GameObject AddName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddTransform(this GameObject gameObject, Transform transform)
        {
            gameObject.transform.position = transform.position;
            return gameObject;
        }

        public static GameObject AddHitSystem(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<HitLandingComponentSystem>();
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}
