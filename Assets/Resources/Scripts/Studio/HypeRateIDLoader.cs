using UnityEngine;
using Newtonsoft.Json.Linq;
using System.IO;

public class SetHyperateID : MonoBehaviour
{
    private string userDataFileName = "userdata.json";
    private string userDataFilePath;
    private string hyperateID;

    private void Start()
    {
        // Setze den Dateipfad f�r die Benutzerdaten
        userDataFilePath = Path.Combine(Application.persistentDataPath, userDataFileName);

        // Lese die Benutzerdaten aus der JSON-Datei
        LoadUserData();
    }

    private void LoadUserData()
    {
        if (File.Exists(userDataFilePath))
        {
            // Lese den Inhalt der JSON-Datei
            string jsonUserData = File.ReadAllText(userDataFilePath);

            // Deserialisiere die JSON-Daten
            JObject userData = JObject.Parse(jsonUserData);

            // Extrahiere die Hyperate-ID aus den Benutzerdaten
            hyperateID = userData["hyperateID"].ToString();

            // Setze die Hyperate-ID im hyperateSocket-Skript
            hyperateSocket socketScript = FindObjectOfType<hyperateSocket>();
            if (socketScript != null)
            {
                socketScript.hyperateID = hyperateID;
                Debug.Log("Hyperate ID gesetzt: " + hyperateID);
            }
            else
            {
                Debug.LogWarning("HyperateSocket-Skript nicht gefunden!");
            }
        }
        else
        {
            Debug.LogWarning("Benutzerdaten-Datei nicht gefunden!");
        }
    }
}
