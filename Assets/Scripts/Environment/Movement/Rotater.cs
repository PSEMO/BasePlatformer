using PSEMO.Environment.Functionality;
using UnityEngine;

namespace PSEMO.Environment.Movement
{
    public class Rotater : MonoBehaviour, IPoolable
    {
        [SerializeField] private float rotationSpeed = 90f;
        [SerializeField] private Vector3 rotationAxis = Vector3.forward;

        private Quaternion initialRotation;

        void Start()
        {
            initialRotation = transform.rotation;
        }

        private void Update()
        {
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
        }

        public void ResetObject()
        {
            transform.rotation = initialRotation;
        }
    }
}