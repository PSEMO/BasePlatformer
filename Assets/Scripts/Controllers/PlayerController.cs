using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerSO data;

    void Start()
    {
        CameraManager.instance.AddTarget(transform, data.camDivisor);
    }

    void OnDestroy()
    {
        CameraManager.instance.RemoveTarget(transform);
    }
}