using UnityEngine;
using PSEMO.Core.Management;

namespace PSEMO.Environment.Functionality.Collectible
{

    public class Collectible : MonoBehaviour
    {
        [SerializeField] CollectibleSO data;

        [HideInInspector] public bool isCollected = false;

        void OnTriggerEnter2D(Collider2D _)
        {
            HandleContact();
        }
        void OnCollisionEnter2D(Collision2D _)
        {
            HandleContact();
        }

        public void HandleContact()
        {
            isCollected = true;
            Events.InvokeCollectibleCollected(data.group);
            gameObject.SetActive(false);
        }
    }
}