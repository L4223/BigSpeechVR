using UnityEngine;
using System.Collections.Generic;

public class GraphDisplay : MonoBehaviour
{
    public hyperateSocket socket; // Weise dem Socket-Objekt im Inspector zu

    public Color lineColor = Color.red; // Setze die Linienfarbe auf Rot

    private Texture2D lineTexture; // Textur für die Linien

    private float zigzagAmplitude = 10f; // Amplitude des Zackenmusters
    private float zigzagFrequency = 1.5f; // Frequenz des Zackenmusters

    void Start()
    {
        // Erstelle eine Textur für die Linien
        lineTexture = new Texture2D(1, 1);
        lineTexture.SetPixel(0, 0, lineColor);
        lineTexture.Apply();
    }

    void OnGUI()
    {
        // Zeichenbereich und Position für den Graphen
        Rect graphRect = new Rect(10, 10, 400, 200);

        // Zeichne einen Hintergrund für den Graphen
        GUI.Box(graphRect, GUIContent.none);

        // Zeichne den horizontalen Graphen basierend auf den empfangenen Pulswerten
        if (socket != null && socket.heartRateData.Count > 1)
        {
            List<int> heartRateData = socket.heartRateData;
            float xStep = graphRect.width / (heartRateData.Count - 1);
            float maxValue = Mathf.Max(heartRateData.ToArray());

            float yOffset = graphRect.y + graphRect.height / 2f;

            Vector2 prevPoint = Vector2.zero;

            for (int i = 0; i < heartRateData.Count; i++)
            {
                float x = graphRect.x + i * xStep;
                float y = yOffset - zigzagAmplitude * Mathf.Sin(zigzagFrequency * x);

                Vector2 currentPoint = new Vector2(x, y);

                if (i > 0)
                {
                    // Zeichne eine Linie zwischen den aktuellen und vorherigen Punkten
                    DrawLine(prevPoint, currentPoint);
                }

                prevPoint = currentPoint;
            }
        }
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        Vector2 difference = end - start;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        GUIUtility.RotateAroundPivot(angle, start);
        GUI.DrawTexture(new Rect(start.x, start.y, difference.magnitude, 2), lineTexture);
        GUIUtility.RotateAroundPivot(-angle, start);
    }
}
