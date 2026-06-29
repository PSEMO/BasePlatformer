using UnityEngine;

public class MakeColChild : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(transform);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        col.transform.SetParent(null);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        col.transform.SetParent(null);
    }
}
