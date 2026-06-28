using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;

public class KillSelf : MonoBehaviour
{
    [SerializeField] float secondsToDieAfter = 2;

    void Start()
    {
        StartCoroutine(killSelfAfterSeconds(secondsToDieAfter));
    }

    IEnumerator killSelfAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(secondsToDieAfter);
        Destroy(gameObject);
    }
}