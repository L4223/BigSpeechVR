using UnityEngine;
using TMPro; // Importiere die TextMeshPro-Namespace
using System.Linq;
using System;
using System.IO;
using Animation;
using System.Collections.Generic;

public class PopupController : MonoBehaviour
{
    public GameObject curtainObject;
    private GameObject popupInstance;
    public DataHandler dataHandler;

    private string DirectoryPath;
    private Main Main;
    public NPCController nPCController;

  

    private void Start()
    {
        
        Main = GameObject.FindWithTag("Main").GetComponent<Main>();
        string presentationName = Main.FileHandler.Directory;

        DirectoryPath = Path.Combine(Application.persistentDataPath, presentationName);
    }

    public void EndPresentation()
    {
        //nPCController.clapping();
        dataHandler.SaveAllData();

        Invoke("ShowNewestPopup", 2.5f);

        StartCloseAnimation();
    }

    public void ShowPopup(string dataName)
    {
        GameObject endPopup = GameObject.Find("EndPopup");


        if (endPopup != null)
        {
            CreatePopupInstance(dataName);
        } else
        {
            Destroy(popupInstance);
            CreatePopupInstance(dataName);
        }       
    }

    private void CreatePopupInstance(string dataName)
    {
        Main.ActivateRayInteractor();
        Main.DeactivateAccessoiresOnOrigin();
        GameObject popupPrefab = Resources.Load<GameObject>("Prefabs/Studio/Prefabs/EndPopup");

        if (popupPrefab == null)
        {
            Debug.LogError("Popup prefab not found in Resources folder.");
            return;
        }

        // Popup erstellen und instanziieren
        popupInstance = Instantiate(popupPrefab, new Vector3(1.76f, 2.79f, 29.92f), Quaternion.Euler(0f, 180f, 0f));


        Data data = GetDataFromJSON(dataName);
        UpdateAllData(data);
    }

    private Data GetDataFromJSON(string fileName)
    {
        string filePath = Path.Combine(DirectoryPath, fileName + ".json");

        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
        {
            Debug.LogError("JSON file not found: " + fileName);
            return null;
        }

        try
        {
            // Lese den Inhalt der JSON-Datei
            string jsonContent = File.ReadAllText(filePath);

            // Deserialisiere den Inhalt in ein Objekt
            Data data = JsonUtility.FromJson<Data>(jsonContent);

            return data;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error reading JSON file: " + ex.Message);
            return null;
        }
    }

    public void ShowNewestPopup()
    {
        Debug.Log("NewestPopup...");
        string dataName = FindNewestJSONFile();

        Debug.Log("Newest file:  " + dataName);

        if (dataName != null)
        {
            ShowPopup(dataName);
        }
        else
        {
            Debug.LogError("No JSON files found in the directory.");
        }
    }

    private string FindNewestJSONFile()
    {
        try
        {
            // Hole alle JSON-Dateien im Verzeichnis
            string[] files = Directory.GetFiles(DirectoryPath, "*.json");

            if (files.Length == 0)
            {
                return null;
            }

            // Sortiere die Dateien nach dem Erstellungsdatum, aufsteigend
            Array.Sort(files, (a, b) => File.GetCreationTime(a).CompareTo(File.GetCreationTime(b)));

            // Greife auf die letzte Datei in der sortierten Liste zu (die neueste JSON-Datei)

            string processedName = Path.GetFileName(files.LastOrDefault());

            processedName = processedName.Replace(".json", "");

            return processedName;
        }
        catch (Exception ex)
        {
            Debug.LogError("Error finding JSON files: " + ex.Message);
            return null;
        }
    }

    private void UpdateAllData(Data data)
    {
        if (data == null)
        {
            Debug.LogError("Data object is null.");
            return;
        }

        UpdateTimeText(data.minutes, data.seconds);

        UpdateBulletpointsText(data.notesCount);
        UpdateFillerText(data.fillerCount);
        UpdatePulseText(data.averagePulse, data.minPulse, data.maxPulse);
    }

    private void UpdateTimeText(int Min_Text, int Sec_Text)
    {
        // Den Text im Popup aktualisieren
        TextMeshProUGUI[] textElements = popupInstance.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textElement in textElements)
        {
            if (textElement.CompareTag("Min_Text"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = Min_Text + " Minuten";
            }
            if (textElement.CompareTag("Sec_Text"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = Sec_Text + " Sekunden";
            }
        }
    }

    private void UpdateFillerText(int fillerCount)
    {
        // Den Text im Popup aktualisieren
        TextMeshProUGUI[] textElements = popupInstance.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textElement in textElements)
        {
            if (textElement.CompareTag("Filler_Text"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = fillerCount + " F�llw�rter";
            }
        }
    }

    private void UpdatePulseText(int Pulse_Text, int Pulse_Max, int Pulse_Min)
    {
        // Den Text im Popup aktualisieren
        TextMeshProUGUI[] textElements = popupInstance.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textElement in textElements)
        {
            if (textElement.CompareTag("Pulse_Text"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = Pulse_Text + " bpm";
            }
            if (textElement.CompareTag("Pulse_Max"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = "max. " + Pulse_Max + " bpm";
            }
            if (textElement.CompareTag("Pulse_Min"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = "min. " + Pulse_Min + " bpm";
            }
        }
    }

    private void UpdateBulletpointsText(int Bulletpoints_Text)
    {
        // Den Text im Popup aktualisieren
        TextMeshProUGUI[] textElements = popupInstance.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textElement in textElements)
        {
            if (textElement.CompareTag("Bulletpoints_Text"))
            {
                // Hier kannst du den Text aktualisieren oder weitere Operationen ausf�hren
                textElement.text = Bulletpoints_Text.ToString() + " W�rter abgehakt";
            }
        }
    }

    private void StartCloseAnimation()
    {
        CloseAnimation closeAnimation = curtainObject.GetComponent<CloseAnimation>();
        closeAnimation.enabled = true;
    }

}

