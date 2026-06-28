using UnityEngine;

public class FallerController : MonoBehaviour, IResettable
{
    [SerializeField] private FallerSO data;
    
    private float currentSpeed = 0f;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        if (currentSpeed >= data.maxSpeed)
        {
            transform.Translate(Vector3.down * (data.maxSpeed * Time.deltaTime));
        }
        else
        {
            currentSpeed += data.gravity * Time.deltaTime;
            transform.Translate(Vector3.down * (currentSpeed * Time.deltaTime));
        }
    }

    public void ResetObject()
    {
        currentSpeed = 0f;
        transform.position = initialPos;
    }
}