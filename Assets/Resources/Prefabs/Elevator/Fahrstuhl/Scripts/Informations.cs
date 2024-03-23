using UnityEngine;


namespace ElevatorPrefab
{
    public class Information : MonoBehaviour
    {
        [Header("Features")] 
        public bool voice;
        public bool pulse;
        public bool publicum;


        public Main Main { set; get; }
        public Elevator Elevator { set; get; }

        public void SetVoice()
        {
            voice = !voice;
        }

        public void SetPulse()
        {
            pulse = !pulse;
        }

        public void SetPublicum()
        {
            publicum = !publicum;
        }

        public void StartPresentation()
        {
            Main = GameObject.FindWithTag("Main").GetComponent<Main>();
            Elevator = GameObject.FindWithTag("Elevator").GetComponent<Elevator>();
            Main.Settings.Voice = voice;
            Main.Settings.Pulse = pulse;
            Main.Settings.Publicum = publicum;
            Elevator.StartPresentation();
        }

    }
}