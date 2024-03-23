using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.XR.Interaction.Toolkit;


public class Main : MonoBehaviour
{
 

    [FormerlySerializedAs("EventSystem")] [SerializeField]
    private GameObject eventSystem;
    
    [FormerlySerializedAs("XRInteractionManager")] [SerializeField]
    private GameObject xrInteractionManager;
    
    [FormerlySerializedAs("InputActionManager")] [SerializeField]
    private GameObject inputActionManager;
    
    [SerializeField]
    private GameObject accessoiresOnOrigin;
    
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;

    public Transform XrOriginTransform { set; get; }

    public XRInteractorLineVisual RayInteractorLeftController;
    public XRInteractorLineVisual RayInteractorRightController;
    public XRInteractorLineVisual RayInteractorLeftHand;
    public XRInteractorLineVisual RayInteractorRightHand;
    
    
    public Vector3 PlayerStartPositionInStudio {set; get;}
    public Quaternion PlayerStartRotationInStudio {set; get;}
    public Vector3 PlayerStartPositionInTutorial {set; get;}
    public Quaternion PlayerStartRotationInTutorial {set; get;}
    
    private Vector3 _nextPlayerPosition;
    private Quaternion _nextPlayerRotation;
    
    private GameObject _blackScreen;
    public GameObject BlackScreen { set; get; }


    public GameObject Player { set; get; }
    public Vector3 PlayerPosition { set; get; }

    
    public FileHandler.FileHandler FileHandler { set; get; }

    public Settings.Settings Settings { set; get; }
    
    bool _needForTutorial;


    // Start is called before the first frame update
    void Start()
    {
        

      

        _needForTutorial = NeedForTutorial();


        
        _nextPlayerPosition = new Vector3(0, 0, 0);
        _nextPlayerRotation = Quaternion.Euler(0, 0, 0);
        
        Player = GameObject.FindWithTag("Player");
        PlayerPosition = Player.GetComponent<Transform>().position;

        FileHandler = new FileHandler.FileHandler();
        Settings = new Settings.Settings();
       
        PlayerStartPositionInStudio = new Vector3(-5.73f, 2.23f, 35.42f); 
        PlayerStartRotationInStudio = Quaternion.Euler(0, 180, 0);

        PlayerStartPositionInTutorial = new Vector3(-4.044909f, 1.8f, 24.6791167f);
        PlayerStartRotationInTutorial = Quaternion.Euler(0f, 0f, 0f);

        
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(Player);
        DontDestroyOnLoad(eventSystem);
        DontDestroyOnLoad(xrInteractionManager);
        DontDestroyOnLoad(inputActionManager);

        StartCoroutine(WaitForSeconds(3,  _needForTutorial));




    }
    

    
    public void ChangePositionAndRotationOfPlayer (Vector3 position, Quaternion rotation)
    {
        Player.transform.position = position;
        Player.transform.rotation = rotation;
    }
    
    public void PlayerPositionInStudio()
    {
        _nextPlayerPosition = PlayerStartPositionInStudio;
        _nextPlayerRotation = PlayerStartRotationInStudio;
    }
    
    public void PlayerPositionInTutorial()
    {
        _nextPlayerPosition = PlayerStartPositionInTutorial;
        _nextPlayerRotation = PlayerStartRotationInTutorial;
    }
    
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangePositionAndRotationOfPlayer(_nextPlayerPosition, _nextPlayerRotation);
    }
    
    public IEnumerator WaitForSeconds(float seconds, bool tutorial)
    {
        yield return new WaitForSeconds(seconds);

        if (tutorial)
        {
            if (leftHand.activeInHierarchy && rightHand.activeInHierarchy)
            {
                FileHandler.Directory = "Tutorial_Hands";
            }
            else
            {
                FileHandler.Directory = "Tutorial_Controller";
            }



            PlayerPositionInTutorial();
            SceneManager.LoadScene("Tutorial");
            
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            SceneManager.LoadScene("Elevator");
            DeactivateAccessoiresOnOrigin();

        }
    }

    
    public void ActivateAccessoiresOnOrigin()
    {
        accessoiresOnOrigin.SetActive(true);
    }
    
    public void DeactivateAccessoiresOnOrigin()
    {
        accessoiresOnOrigin.SetActive(false);
    }
    
    public void DeactivateRayInteractor()
    {
        RayInteractorLeftController.enabled = false;
        RayInteractorRightController.enabled = false;
        RayInteractorLeftHand.enabled = false;
        RayInteractorRightHand.enabled = false;
    }
    
    public void ActivateRayInteractor()
    {
        RayInteractorLeftController.enabled = true;
        RayInteractorRightController.enabled = true;
        RayInteractorLeftHand.enabled = true;
        RayInteractorRightHand.enabled = true;
    }
 
    bool NeedForTutorial()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
        int i = 0;
        foreach (var json in directoryInfo.GetFiles("*.json"))
        {
            i++;
            Debug.Log(json.Name);
            Debug.Log(i);
        }
        if (i == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    

    

    





}
