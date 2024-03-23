using System.Collections.Generic;
using UnityEngine;

public class PulseGraph : MonoBehaviour
{
    public LineRenderer lineRenderer;

    private List<int> pulseData = new List<int> {
        80, 85, 90, 95, 160, 105, 110, 115, 120, 125,
        130, 90, 85, 80, 100, 155, 90, 93, 170, 175
    };

    private void Start()
    {
        CreateGraph();
    }

    private void CreateGraph()
    {
        // Berechnen des Skalierungsfaktors basierend auf der gewünschten Länge des Graphen
        float scaleFactor = 400f / (pulseData.Count - 1);

        // Setzen der Anzahl der Positionen für die Linie
        lineRenderer.positionCount = 400;

        // Iterieren über die Positionen im LineRenderer
        for (int i = 0; i < 400; i++)
        {
            // Berechnen des Indexes im Pulsdaten-Array basierend auf der aktuellen Position
            float dataIndex = i / scaleFactor;
            // Abrunden des Indexes
            int index = Mathf.Clamp(Mathf.RoundToInt(dataIndex), 0, pulseData.Count - 1);
            // Setzen der Position der Linie entsprechend des Indexes und der Pulsdatenwerts
            lineRenderer.SetPosition(i, new Vector3(i, pulseData[index], 0));
        }
    }
}
