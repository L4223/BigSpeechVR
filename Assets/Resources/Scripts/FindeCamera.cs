using UnityEngine;

public class SetCameraAsRenderCamera : MonoBehaviour
{

    private GameObject cam;
    private void Start()
    {
        // Finde das Canvas mit dem Tag "LevelChanger"
        GameObject levelChanger = GameObject.FindGameObjectWithTag("LevelChanger");
        cam = GameObject.FindWithTag("MainCamera");
        

        if (levelChanger != null)
        {
            // Hole das Canvas-Component des GameObjects
            Canvas canvas = levelChanger.GetComponent<Canvas>();

            // Überprüfe, ob das Canvas vorhanden ist und ob sich die Kamera im selben Hierarchieast befindet
            if (canvas != null && GetComponent<Camera>() != null)
            {
                // Canvas-Render-Modus auf Screen Space - Camera setzen
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = cam.GetComponent<Camera>();
            }
            else
            {
                Debug.LogWarning("Canvas or Camera component not found.");
            }
        }
        else
        {
            Debug.LogWarning("GameObject with tag 'LevelChanger' not found.");
        }
    }
}
