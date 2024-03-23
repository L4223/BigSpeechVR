using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class PopulateButtonList : MonoBehaviour
{
    public GameObject buttonPrefab; // Prefab des Buttons
    public RectTransform buttonPanel; // Das Panel, in dem die Buttons erstellt werden sollen
    private string DirectoryPath; // Pfad zum Ordner mit den JSON-Dateien
    private PopupController popupController;

    private Main Main;


    void Start()
    {

        
        Main = GameObject.FindWithTag("Main").GetComponent<Main>();
        string presentationName = Main.FileHandler.Directory;

        popupController = FindObjectOfType<PopupController>();
        if (popupController == null)
        {
            Debug.LogError("PopupController not found in the scene.");
        }

        DirectoryPath = Path.Combine(Application.persistentDataPath, presentationName);
        PopulateList();
    }

    void PopulateList()
    {
        // Hole alle JSON-Dateien im Verzeichnis
        string[] files = Directory.GetFiles(DirectoryPath, "*.json");

        // Für jede JSON-Datei einen Button erstellen und im Panel platzieren
        foreach (string file in files)
        {
            // Den Dateinamen ohne Erweiterung erhalten
            string fileName = Path.GetFileNameWithoutExtension(file);

            // Button-Instanz aus dem Prefab erstellen
            GameObject buttonGO = Instantiate(buttonPrefab, buttonPanel);

            // Den Text des Buttons ändern
            TMP_Text buttonText = buttonGO.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = fileName;
            }

            // Button-Komponente des erstellten Gameobjects abrufen
            Button button = buttonGO.GetComponent<Button>();

            if (button != null)
            {
                // Den Dateinamen an den Button-Click-Eventhandler übergeben
                button.onClick.AddListener(() => LoadFile(fileName));
            }
            else
            {
                Debug.LogError("Button component not found on the instantiated object.");
            }
        }
    }

    // Methode, die aufgerufen wird, wenn ein Button geklickt wird, um die entsprechende JSON-Datei zu laden
    void LoadFile(string fileName)
    {
        // Hier kannst du den Code zum Laden der Datei einfügen
        Debug.Log("Button click  " + fileName);
        popupController.ShowPopup(fileName);
        Debug.Log("Datei geladen: " + fileName);
    }
}
