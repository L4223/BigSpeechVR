using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Importiere den LINQ-Namespace
using System.IO;
using System;

public class DataHandler : MonoBehaviour
{
    public int minutes { get; set; }
    public int seconds { get; set; }

    public List<int> pulseList { get; set; }
    private int averagePulse;
    private int maxPulse;
    private int minPulse;
    public int aehmCounter { get; set; } = 0;
    private int bulletpointCounter;

    public hyperateSocket hyperateSocket;
    public CountAehms countAehms;

    private Main Main;

    private string DirectoryPath; // Pfad zum Ordner mit den JSON-Dateien

    public ChangeText changeText;

    // String aus der Datei
    public string textFromFile;

    public string presentationName { set; get; }

    private void Start()
    {
        Main = GameObject.FindWithTag("Main").GetComponent<Main>();
        presentationName = Main.FileHandler.Directory;

        DirectoryPath = Path.Combine(Application.persistentDataPath, presentationName);
    }

    public void SaveAllData()
    {
        Debug.Log("Saving...");
        GetTimerData();
        GetPulseData();
        GetFillerData();

        try { GetBulletpointsData(); } catch { bulletpointCounter = 0; }
        

        SaveDataToJson();
    }

    public void GetAllData()
    {
        Debug.Log("Saving...");
        GetTimerData();
        GetPulseData();
        GetFillerData();
        Debug.Log("Ähmm--" + aehmCounter);
        GetBulletpointsData();
    }

    private void GetBulletpointsData()
    {
        bulletpointCounter = CountBulletpoints();
    }

    private int CountBulletpoints()
    {

        textFromFile = File.ReadAllText(Path.Combine(DirectoryPath, "notes.txt"));
        Debug.Log("Text1 --- " + textFromFile);
        Debug.Log("Text2 --- " + changeText.savedText);

        // Lade die Liste aus der Datei und verarbeite sie
        List<string> textList1 = ProcessTextFromFile(textFromFile);

          // Zähler für die Übereinstimmungen
        int matchCounter = CountMatches(textList1, changeText.savedText);

        // Gib die Anzahl der Übereinstimmungen aus
        Debug.Log("Anzahl der Übereinstimmungen: " + matchCounter);

        return matchCounter;
    }

    // Verarbeitet den Text aus der Datei
    private List<string> ProcessTextFromFile(string text)
    {
        List<string> textList = new List<string>();

        // Teile den Text an den Trennzeichen ", " auf und füge die Teile zur Liste hinzu
        string[] words = text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            textList.Add(word.Trim()); // Entferne Leerzeichen vor und nach dem Wort
        }

        return textList;
    }

    // Zählt die Übereinstimmungen zwischen den beiden Listen von Strings
    private int CountMatches(List<string> list1, List<string> list2)
    {
        int counter = 0;

        Debug.Log("List 1 --- " + list1);
        Debug.Log("List 2 --- " + list2);

        // Iteriere über jedes Element in der ersten Liste
        foreach (string word1 in list1)
        {
            // Überprüfe, ob das Wort in der ersten Liste auch in der zweiten Liste vorhanden ist
            if (list2.Contains(word1))
            {
                counter++; // Inkrementiere den Zähler, wenn das Wort gefunden wird
            }
        }

        return counter;
    }

    private void GetFillerData()
    {
        aehmCounter = countAehms.Aehms;
    }

    private void GetTimerData()
    {
        PresentationTimer presentationTimer = GetComponent<PresentationTimer>();

        // Auf Minuten und Sekunden des PresentationTimer zugreifen
        minutes = presentationTimer.minutes;
        seconds = presentationTimer.seconds;

        Debug.Log("TimerData: " + minutes + " - " + seconds);
    }

    private void GetPulseData()
    {
        // pulseList = hyperateSocket.heartRateData;
        pulseList = hyperateSocket.heartRateData;

        try
        {
            // Durchschnitt
            averagePulse = Mathf.RoundToInt(((float)pulseList.Average()));

            // Finde den größten Wert
            maxPulse = pulseList.Max();

            // Finde den kleinsten Wert
            minPulse = pulseList.Min();

            Debug.Log("PulseData: " + averagePulse + " - " + maxPulse + " - " + minPulse);
        } catch
        {
            Debug.Log("No Pulse Data found.");
            averagePulse = 0;

            // Finde den größten Wert
            maxPulse = 0;

            // Finde den kleinsten Wert
            minPulse = 0;

        }

        
    }

    private void SaveDataToJson()
    {
        // JSON-Daten erstellen
        Data data = new Data(minutes, seconds, averagePulse, maxPulse, minPulse, aehmCounter, bulletpointCounter);

        // JSON-Daten serialisieren
        string jsonData = JsonUtility.ToJson(data);

        // Eindeutigen Dateinamen aus Präsentationsnamen und TimeStamp erstellen
        string timeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string fileName = $"{timeStamp}.json";
        string filePath = Path.Combine(DirectoryPath, fileName);

        // Prüfen, ob das Verzeichnis existiert, und es erstellen, falls nicht
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }

        // JSON-Daten in Datei speichern
        File.WriteAllText(filePath, jsonData);
    }

}
