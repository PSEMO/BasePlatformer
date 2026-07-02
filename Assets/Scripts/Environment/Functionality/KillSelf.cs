using System.Collections;
using UnityEngine;
using PSEMO.Events;

namespace PSEMO.Environment.Functionality
{
    public class KillSelf : MonoBehaviour
    {
        [SerializeField] float secondsToDieAfter = 2;

        void OnEnable()
        {
            StartCoroutine(KillSelfAfterSeconds(secondsToDieAfter));
        }

        IEnumerator KillSelfAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            PoolingEvents.InvokeDeSpawnObject(gameObject);
        }
    }
}