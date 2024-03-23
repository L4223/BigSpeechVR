using UnityEngine;
using TMPro; // Importiere den TextMeshPro-Namespace

public class PresentationTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Verwende TextMeshProUGUI für TMP-Text

    public int minutes { get; private set; }
    public int seconds { get; private set; }

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        minutes = Mathf.FloorToInt(elapsedTime / 60f);
        seconds = Mathf.FloorToInt(elapsedTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
