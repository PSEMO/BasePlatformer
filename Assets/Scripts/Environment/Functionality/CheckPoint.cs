using UnityEngine;
using PSEMO.Events;

namespace PSEMO.Environment.Functionality
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        public Vector3 SpawnPos => spawnPoint.position;

        private void OnTriggerEnter2D(Collider2D _)
        {
            PlayerEvents.InvokeCheckPointReached(SpawnPos);
        }
    }
}