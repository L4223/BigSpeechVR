using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Controller : MonoBehaviour
{
    public PresentationOnLeinwand leinwand;
    private int counter;
    public GameObject welcome;
    public GameObject controller;
    public GameObject hands;
    public GameObject features;
    public GameObject presentation;
    public GameObject notes;
    public GameObject danke;

    public Animator animator;

    private int previousSlideCounter = -1;

    // Start is called before the first frame update
    void Start()
    {
        // Setze alle GameObjects zu Beginn auf deaktiviert
        SetAllGameObjectsActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        counter = leinwand.slideCounter;
        Debug.Log("Counter -- " + counter);

        // Überprüfe, ob sich der SlideCounter geändert hat
        if (counter != previousSlideCounter)
        {
            // Deaktiviere das vorherige GameObject
            DeactivatePreviousGameObject();

            // Aktiviere das entsprechende GameObject basierend auf dem SlideCounter
            ActivateGameObject(counter);

            // Aktualisiere den vorherigen SlideCounter
            previousSlideCounter = counter;

            animator.SetTrigger("talk");
            Invoke("resetAnimator", 1.5f);
        }
    }

    private void resetAnimator()
    {
        animator.SetTrigger("stand");
    }

    // Aktiviere das entsprechende GameObject basierend auf dem SlideCounter
    private void ActivateGameObject(int slideCounter)
    {
        switch (slideCounter)
        {
            case 0:
                welcome.SetActive(true);
                break;
            case 1:
                controller.SetActive(true);
                break;
            case 2:
                hands.SetActive(true);
                break;
            case 3:
                features.SetActive(true);
                break;
            case 4:
                presentation.SetActive(true);
                break;
            case 5:
                notes.SetActive(true);
                break;
            case 6:
                danke.SetActive(true);
                break;
            default:
                break;
        }
    }

    // Deaktiviere das vorherige GameObject
    private void DeactivatePreviousGameObject()
    {
        switch (previousSlideCounter)
        {
            case 0:
                welcome.SetActive(false);
                break;
            case 1:
                controller.SetActive(false);
                break;
            case 2:
                hands.SetActive(false);
                break;
            case 3:
                features.SetActive(false);
                break;
            case 4:
                presentation.SetActive(false);
                break;
            case 5:
                notes.SetActive(false);
                break;
            case 6:
                danke.SetActive(false);
                break;
            default:
                break;
        }
    }

    // Setze alle GameObjects auf aktiviert oder deaktiviert
    private void SetAllGameObjectsActive(bool active)
    {
        welcome.SetActive(active);
        controller.SetActive(active);
        hands.SetActive(active);
        features.SetActive(active);
        presentation.SetActive(active);
        notes.SetActive(active);
        danke.SetActive(active);
    }
}
