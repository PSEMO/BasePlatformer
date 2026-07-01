using UnityEngine;

namespace PSEMO.Environment.Functionality
{
    [RequireComponent(typeof(IPoolable))]
    public class Pooler : MonoBehaviour
    {
        [SerializeField] private string groupName;
        public string GroupName { get => groupName; }

        IPoolable poolable;

        void Awake()
        {
            poolable = GetComponent<IPoolable>();
        }

        public void ResetObject()
        {
            poolable.ResetObject();
        }
    }
}