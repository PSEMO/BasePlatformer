using UnityEngine;
using PSEMO.Events;

namespace PSEMO.Environment.Functionality
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class KillBox : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D _)
        {
            PlayerEvents.InvokePlayerDeath();
        }
    }
}