using System;
using UnityEngine;

namespace PSEMO.Events
{
    public static class PoolingEvents
    {
        public static event Func<GameObject, Vector3, Quaternion, Transform, GameObject> OnSpawnObject;
        public static GameObject InvokeSpawnObject(GameObject obj, Vector3 pos, Quaternion rotation, Transform parent = null)
        {
            if (OnSpawnObject != null)
                return OnSpawnObject.Invoke(obj, pos, rotation, parent);
            else
                return UnityEngine.Object.Instantiate(obj, pos, rotation, parent);
        }

        public static event Action<GameObject> OnDeSpawnObject;
        public static void InvokeDeSpawnObject(GameObject obj)
        {
            if (OnDeSpawnObject == null)
                UnityEngine.Object.Destroy(obj);
            else
                OnDeSpawnObject.Invoke(obj);
        }
    }
}