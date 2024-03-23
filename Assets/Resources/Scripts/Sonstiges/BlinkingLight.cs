using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private bool isVisible = true;
    private GameObject blinkingLight;
    public float speed = 2f;



    private void Start()
    {
        // Finde das GameObject mit dem Namen "blinking light".
        //blinkingLight = GameObject.Find("blinking_light");

        blinkingLight = gameObject;

        // Starte die Coroutine, um die Sphere zu verwalten.
        StartCoroutine(ToggleVisibilityRoutine());
    }

    private IEnumerator ToggleVisibilityRoutine()
    {
        while (true)
        {
            // Warte 2 Sekunden, bevor die Sphere verschwindet.
            yield return new WaitForSeconds(speed);

            // Ändere die Sichtbarkeit des Mesh Renderers des "blinking light" GameObjects.
            MeshRenderer meshRenderer = blinkingLight.GetComponent<MeshRenderer>();

            if (meshRenderer != null)
            {
                isVisible = !isVisible;
                meshRenderer.enabled = isVisible;
            }
           
        }
    }
}
