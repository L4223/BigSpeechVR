using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandMenuActions : MonoBehaviour
{
    private PopupController popupController;
    private DataHandler dataHandler;
    private bool objectsInitialized = false;

    public TMP_Text pulse;
    public TMP_Text filler;
    public TMP_Text timer;

    private void Update()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Pr�fe, ob die Szene "Studio" ist
        if (currentSceneName == "Studio")
        {
            // F�hre die Initialisierung der Objekte nur einmal aus
            if (!objectsInitialized)
            {
                GetObjects();
                objectsInitialized = true;
            }

            hyperateSocket hype = GameObject.FindGameObjectWithTag("DataHandler").GetComponent<hyperateSocket>();

            // Versuche, die Daten zu aktualisieren
                     
                

                // F�hre GetAllData aus und aktualisiere die UI-Texte
                if (dataHandler != null)
                {
                    dataHandler.GetAllData();
                    timer.text = dataHandler.minutes + ":" + dataHandler.seconds;
                    filler.text = dataHandler.aehmCounter.ToString();

                    Debug.Log("�hmm--" + dataHandler.aehmCounter.ToString());
                    try
                    {

                    //string lastPulse = dataHandler.pulseList[dataHandler.pulseList.Count - 1].ToString();
                    string pulsetext = hype.heartRate.ToString();
                    pulse.text = pulsetext + " bpm";
                    }
                    catch (System.Exception)
                    {
                        pulse.text = "0 bpm";
                        throw;
                    }

                }
           
        }
        // Setze die Flag zur�ck, wenn die Szene nicht mehr "Studio" ist
        else
        {
            objectsInitialized = false;
        }
    }

    // Diese Methode initialisiert die erforderlichen Objekte
    private void GetObjects()
    {
        // Finde das GameObject mit dem DataHandler-Skript
        GameObject dataHandlerObject = GameObject.FindWithTag("DataHandler");

        // �berpr�fe, ob das GameObject gefunden wurde
        if (dataHandlerObject != null)
        {
            // Hole das DataHandler-Skript vom GameObject
            dataHandler = dataHandlerObject.GetComponent<DataHandler>();
            popupController = dataHandlerObject.GetComponent<PopupController>();
        }
        else
        {
            Debug.LogWarning("GameObject with tag 'DataHandler' not found.");
        }
    }

    public void GetEndPresentation()
    {
        // Rufe die EndPresentation-Funktion auf dem PopupController auf
        popupController.EndPresentation();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Studio");
    }
}
