using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CounterForPresentationSlides : MonoBehaviour
{
    
    public int SlideCounter {set; get;}

    private PresentationOnLeinwand Presentation;
    private PresentationOnLeinwand Teleprompter;

    private string currentSceneName;


    // Start is called before the first frame update
    void Start()
    {
        SlideCounter = 0;    
    }

    private void setReferences()
    {
        Presentation = GameObject.FindWithTag("Leinwand").GetComponent<PresentationOnLeinwand>();
        Teleprompter = GameObject.FindWithTag("Teleprompter").GetComponent<PresentationOnLeinwand>();
    }

    private void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if(currentSceneName == "Tutorial" && Presentation == null || currentSceneName == "Studio" && Presentation == null)
        {
            Debug.Log("setReferences!");
            setReferences();
        }
    }
    
    public void NextSlide()
    {
        // SlideCounter++;
        Presentation.NextSlide();
        Teleprompter.NextSlide();
    }
    
    public void PreviousSlide()
    {
        Presentation.PreviousSlide();
        Teleprompter.PreviousSlide();
        // if (SlideCounter > 0)
        // {
        //     SlideCounter--;
        //
        // }

    }


}
