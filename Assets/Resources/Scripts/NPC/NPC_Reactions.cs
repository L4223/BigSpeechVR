using System.Threading;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    private GameObject[] characters;
    private Animator[] animators;

    public CountAehms countAehms;
    public PresentationTimer timer;
    public AudioSource applause;


    private void Start()
    {
        
        // Du kannst eine Liste von GameObjects verwenden, um mehrere Charaktere zu speichern
        characters = GameObject.FindGameObjectsWithTag("Interactive_NPC");
        animators = new Animator[characters.Length];

        for (int i = 0; i < characters.Length; i++)
        {
            Animator animator = characters[i].GetComponent<Animator>();
            if (animator != null)
            {
                animators[i] = animator;
            }
            else
            {
                Debug.LogWarning("Der Charakter " + characters[i].name + " hat keinen Animator.");
            }
        }

        Invoke("clapping", 6.5f);

    }

    private void Update()
    {
        reactToFiller();
        reactToTime();
    }

    private int savedAehms;

    private void reactToFiller()
    {
        if (countAehms.Aehms - savedAehms > 0)
        {
            if (countAehms.Aehms == 3 || countAehms.Aehms == 6 || countAehms.Aehms == 9 || countAehms.Aehms == 12 || countAehms.Aehms == 15 || countAehms.Aehms == 20 || countAehms.Aehms == 25)
            {
                Debug.Log("Ahms  -  " + countAehms.Aehms);
                badmood();
                savedAehms = countAehms.Aehms;
            }
        }
    }

    private void reactToTime()
    {
            if (timer.minutes == 3  && timer.seconds == 0|| timer.minutes == 6 && timer.seconds == 0 || timer.minutes == 10 && timer.seconds == 0 || timer.minutes == 13 && timer.seconds == 0)
            {
                Debug.Log("Timer  -  " + timer.minutes);
                clapping();
            }
    }


    public void clapping()
    {
        applause.Play();
        foreach (Animator animator in animators)
        {
            Debug.Log("Durchnummeriert");
            //  berpr fe, ob der Charakter ein Animator-Komponente hat
            if (animator != null)
            {
                // Setze den Trigger "Clap" im Animator
                animator.SetTrigger("Clap");
                

                // Rufe die Methode zum Zur ckkehren zur Idle-Animation nach 5 Sekunden auf
                Invoke("BackToDefault", 5f);
            }
        } 
    }

    public void badmood()
    {
        foreach (Animator animator in animators)
        {
            //  berpr fe, ob der Charakter ein Animator-Komponente hat
            if (animator != null)
            {
                // Setze den Trigger "Clap" im Animator
                animator.SetTrigger("Bad");

                // Rufe die Methode zum Zur ckkehren zur Idle-Animation nach 5 Sekunden auf
                Invoke("BackToDefault", 3f);
            }
        }
    }

    private void BackToDefault()
    {
        foreach (Animator animator in animators)
        {
            // Setze den Trigger "BackToIdle" im Animator
            animator.SetTrigger("Sit");
        }
    }
}