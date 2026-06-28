using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    [SerializeField] float secondsToDieAfter = 2;

    void Start()
    {
        StartCoroutine(KillSelfAfterSeconds(secondsToDieAfter));
    }

    IEnumerator KillSelfAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(secondsToDieAfter);
        Destroy(gameObject);
    }
}