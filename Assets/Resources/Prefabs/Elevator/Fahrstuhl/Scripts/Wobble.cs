using UnityEngine;

namespace ElevatorPrefab
{
    public class ElevatorMovement : MonoBehaviour
    {
        public float wobbleAmount = 0.1f;
        public float wobbleSpeed = 2.0f;

        public Transform elevatorTransform;
        public Vector3 originalPosition;


        private void Start()
        {
            originalPosition = elevatorTransform.position;
        }

        private void Update()
        {
            // F�gen Sie eine Wackelbewegung hinzu
            float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
            elevatorTransform.position = originalPosition + new Vector3(0f, wobble, 0f);
        }
    }
}
