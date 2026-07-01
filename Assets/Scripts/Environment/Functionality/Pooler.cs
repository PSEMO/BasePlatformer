using UnityEngine;

namespace PSEMO.Environment.Functionality
{
    [RequireComponent(typeof(IPoolable))]
    public class Pooler : MonoBehaviour
    {
        [SerializeField] private string groupName;
        public string GroupName { get => groupName; }

        IPoolable[] poolables;

        void Awake()
        {
            poolables = GetComponents<IPoolable>();
        }

        public void ResetObject()
        {
            foreach (IPoolable poolable in poolables)
            {
                poolable.ResetObject();
            }
        }
    }
}