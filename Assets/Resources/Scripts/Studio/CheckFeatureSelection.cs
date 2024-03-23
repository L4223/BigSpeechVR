using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    private Settings.Settings settingsInstance;
    private Main main;

    [SerializeField] private GameObject hyperateSocketObject;
    [SerializeField] private GameObject animatedNPCsObject;
    [SerializeField] private GameObject staticNPCsObject;
    [SerializeField] private GameObject speechToTextObject;
    [SerializeField] private GameObject counterObject;

    private hyperateSocket hyperateSocketScript;

    private void Start()
    {
        main = GameObject.FindWithTag("Main").GetComponent<Main>();
        settingsInstance = main.Settings;

        if (settingsInstance != null)
        {
            CheckSettings();
        }
        else
        {
            Debug.LogError("Settings instance not found!");
        }
    }

    private void CheckSettings()
    {
        // Überprüfe und reagiere auf den Wert von Pulse
        if (!settingsInstance.Pulse)
        {
            hyperateSocketScript = hyperateSocketObject.GetComponent<hyperateSocket>();
            if (hyperateSocketScript != null)
            {
                hyperateSocketScript.enabled = false;
                Debug.Log("HyperateSocket wurde deaktiviert.");
            }
            else
            {
                Debug.LogError("HyperateSocket script not found on the hyperateSocketObject!");
            }
        }

        // Überprüfe und reagiere auf den Wert von Publikum
        if (!settingsInstance.Publicum)
        {
            animatedNPCsObject.SetActive(false);
            staticNPCsObject.SetActive(false);
            Debug.Log("Animated_NPCs und Static_NPCs wurden deaktiviert.");
        }

        // Überprüfe und reagiere auf den Wert von Voice
        if (!settingsInstance.Voice)
        {
            speechToTextObject.SetActive(false);
            counterObject.SetActive(false);
            Debug.Log("SpeechToText und Counter wurden deaktiviert.");
        }
    }
}
