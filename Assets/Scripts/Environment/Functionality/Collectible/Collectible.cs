using PSEMO.Audio;
using UnityEngine;
using PSEMO.Events;

namespace PSEMO.Environment.Functionality.Collectible
{

    public class Collectible : MonoBehaviour
    {
        [SerializeField] CollectibleSO data;

        [HideInInspector] public bool isCollected = false;

        void OnTriggerEnter2D(Collider2D _)
        {
            HandleContact(true);
        }
        void OnCollisionEnter2D(Collision2D _)
        {
            HandleContact(true);
        }

        public void HandleContact(bool PlayAudio = false)
        {
            if (PlayAudio)
                AudioManager.Instance.PlayAudio("Coin");
            
            isCollected = true;
            CollectibleEvents.InvokeCollectibleCollected(data.group);
            gameObject.SetActive(false);
        }
    }
}