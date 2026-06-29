using UnityEngine;

public class Faller : MonoBehaviour, IResettable
{
    [SerializeField] private float maxSpeed = 20f;
    [SerializeField] private float gravity = 9.8f;
    
    private float currentSpeed = 0f;
    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        if (currentSpeed >= maxSpeed)
        {
            transform.Translate(Vector3.down * (maxSpeed * Time.deltaTime));
        }
        else
        {
            currentSpeed += gravity * Time.deltaTime;
            transform.Translate(Vector3.down * (currentSpeed * Time.deltaTime));
        }
    }

    public void ResetObject()
    {
        currentSpeed = 0f;
        transform.position = initialPos;
    }
}