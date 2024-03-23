using Animation;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace ElevatorPrefab
{
    public class ElevatorAnimation : MonoBehaviour
    {

        public Light targetLight;
        public OpenAnimation elevatorDoorController;
        public ElevatorMovement elevatorMovement;

        private readonly float _intensityIncreaseSpeed = 2.5f;
        private readonly float _targetIntensity = 10;
        private bool _doorControllerActivated = false;


        public AudioSource noise;
        public AudioSource bing;
        public AudioSource open;
        
        private Main _main;
        public GameObject stories;

        private Vector3 _newPosition;
        private Quaternion _newRotation;

        // Start is called before the first frame update
        void Start()
        {
            
            //levelChanger = GameObject.FindWithTag("LevelChanger").GetComponent<LevelChanger>();
            _main = GameObject.FindWithTag("Main").GetComponent<Main>();
           
            
        }

        public void StartAnimation(string sceneName)
        {
            StartCoroutine(ActivateElevatorAndChangeScene(sceneName));
        }

        public System.Collections.IEnumerator ActivateElevatorAndChangeScene(string sceneName)
        {
            noise.Play();
            stories.SetActive(true);


            Movement(true);
            yield return new WaitForSeconds(3.0f);
            Movement(false);
            noise.Stop();

            bing.Play();

            open.Play();
            yield return new WaitForSeconds(1.0f);
            

            // Aktiviere das ElevatorDoorController-Skript nach dem Laden der Szene     
            float startTime = Time.time;
            float duration = 2.0f;
            while (targetLight.intensity < _targetIntensity)
            {
                targetLight.intensity += _intensityIncreaseSpeed * Time.deltaTime;

                // Ueberpruefe, ob die Haelfte der Zeit vergangen ist und das ElevatorDoorController noch nicht aktiviert wurde
                if (!_doorControllerActivated && Time.time - startTime >= duration / 5)
                {


                    elevatorDoorController.enabled = true;
                    _doorControllerActivated = true;
                }

                yield return null;
            }

            // if (sceneName == "Studio")
            // {
            //     _newPosition = _main.PlayerStartPositionInStudio;
            //     _newRotation = _main.PlayerStartRotationInStudio;
            // }
            //
            // else if (sceneName == "Tutorial")
            // {
            //     _newPosition = _main.PlayerStartPositionInTutorial;
            //     _newRotation = _main.PlayerStartRotationInTutorial;
            //     sceneName = "Studio";
            //
            // }
            //
            
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += _main.OnSceneLoaded;
            // _main.ActivateAccessoiresOnOrigin();
            // _main.ChangePositionAndRotationOfPlayer(_newPosition, _newRotation);



        }
        
        // private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        // {
        //     _main.ChangePositionAndRotationOfPlayer(_newPosition, _newRotation);
        // }
        
        private void Movement(bool movement)
        {
            elevatorMovement.enabled = movement;
        }
    }
}