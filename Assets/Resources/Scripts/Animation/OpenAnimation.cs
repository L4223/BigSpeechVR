using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class OpenAnimation : MonoBehaviour
    {
        [Header("Sides")][SerializeField] private Transform left;
        [SerializeField] private Transform right;

        [Header("Animation Parameters")]
        [SerializeField] private float speed;
        [SerializeField] private float distance;
        [SerializeField] private float delayInSeconds; // Der Parameter f�r die Verz�gerung in Sekunden

        private bool animationStarted = false;
        private float delayTimer = 0f;


        public void Update()
        {
            // �berpr�fe, ob die Verz�gerung abgelaufen ist
            if (!animationStarted)
            {
                delayTimer += Time.deltaTime;
                if (delayTimer >= delayInSeconds)
                {
                    animationStarted = true;
                }
                else
                {
                    return; // Stoppe die Update-Methode, wenn die Verz�gerung noch nicht abgelaufen ist
                }
            }

            left.Translate(Vector3.left * (speed * Time.deltaTime));
            right.Translate(Vector3.left * (speed * Time.deltaTime));

            distance -= speed * Time.deltaTime;

            if (distance <= 0)
            {
                enabled = false;
            }
        }
    }
}
