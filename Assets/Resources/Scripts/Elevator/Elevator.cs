using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    
        
    private ElevatorPrefab.ElevatorAnimation elevatorAnimation;
    private GameObject _elevator;
    public GameObject ElevatorGameObject { set; get; }
    private GameObject _whiteTransition;
    public GameObject WhiteTransition { set; get; }
    
    private string _prefabsPath = "Prefabs/Elevator/";
    
    private Main _main;

    private Vector3 _cameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        _elevator = Resources.Load(_prefabsPath + "Fahrstuhl/Fahrstuhl") as GameObject;


        _whiteTransition = Resources.Load(_prefabsPath + "Uebergangslicht") as GameObject;
        
        _main = GameObject.FindWithTag("Main").GetComponent<Main>();
        _cameraPosition = GameObject.FindWithTag("MainCamera").transform.position;
        _main.ActivateRayInteractor();


        
        ElevatorScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ElevatorScene()
    {
        _main.PlayerPosition = new Vector3(0, 0, 0);
        // ElevatorGameObject = Instantiate(_elevator,
        //     new Vector3(_main.PlayerPosition.x + 3.5f, _main.PlayerPosition.y, _main.PlayerPosition.z + 2),
        //     Quaternion.Euler(0, 0, 0));
       ElevatorGameObject = Instantiate(_elevator,
            new Vector3(_cameraPosition.x + 3.5f, _cameraPosition.y - 1.36f, _cameraPosition.z + 2),
            Quaternion.Euler(0, 0, 0)); 

        elevatorAnimation = ElevatorGameObject.GetComponentInChildren<ElevatorPrefab.ElevatorAnimation>();
    }
    
    public void StartPresentation()
    {
        Vector3 elevatorPosition = ElevatorGameObject.transform.position;
        _main.PlayerPositionInStudio();
        Instantiate(_whiteTransition, elevatorPosition + new Vector3(-7, -3, 1),
            Quaternion.Euler(0, 90, 0));
        StartCoroutine(elevatorAnimation.ActivateElevatorAndChangeScene("Studio"));
    }
    
    public void StartTutorial()
    {
        Vector3 elevatorPosition = ElevatorGameObject.transform.position;
        _main.PlayerPositionInTutorial();
        Instantiate(_whiteTransition, elevatorPosition + new Vector3(-7, -3, 1),
            Quaternion.Euler(0, 90, 0));
        StartCoroutine(elevatorAnimation.ActivateElevatorAndChangeScene("Tutorial"));
    }
}
