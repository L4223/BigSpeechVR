using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class CloseAnimation : MonoBehaviour
    {
        [Header("Sides")]
        [SerializeField] private Transform left;
        [SerializeField] private Transform right;

        [Header("Animation Parameters")]
        [SerializeField] private float speed;
        [SerializeField] private float distance;

        private void Update()
        {
            left.Translate(Vector3.right * (speed * Time.deltaTime));
            right.Translate(Vector3.right * (speed * Time.deltaTime));

            distance -= speed * Time.deltaTime;

            // Überprüfen, ob der Vorhang die volle Distanz erreicht hat, um die Bewegung zu stoppen
            if (distance <= 0)
            {
                enabled = false;
            }
        }
    }
}
