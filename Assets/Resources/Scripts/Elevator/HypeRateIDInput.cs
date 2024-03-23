using UnityEngine;
using TMPro;
using System.IO;

public class SaveUserData : MonoBehaviour
{
    public TMP_InputField userInputField;

    private string userDataFileName = "userdata.json";
    private string userDataFilePath;

    [System.Serializable]
    private class UserData
    {
        public string hyperateID;
    }

    private void Start()
    {
        // Setze den Dateipfad f�r die Benutzerdaten
        userDataFilePath = Path.Combine(Application.persistentDataPath, userDataFileName);
    }

    public void SaveHyperateID()
    {
        // Erstelle eine Instanz der UserData-Klasse und setze den Wert von hyperateID
        UserData userData = new UserData();
        userData.hyperateID = userInputField.text;

        // Serialisiere die Benutzerdaten in JSON
        string jsonUserData = JsonUtility.ToJson(userData);

        // Schreibe die JSON-Daten in die Datei
        File.WriteAllText(userDataFilePath, jsonUserData);

        Debug.Log("Benutzerdaten wurden gespeichert.");
    }
}
