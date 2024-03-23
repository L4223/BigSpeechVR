using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Hands.Samples.GestureSample;

public class PresentationOnLeinwand : MonoBehaviour
{
    public Main Main { set; get; }
    public FileHandler.FileHandler FileHandler { set; get; }

    private Renderer _leinwandRenderer;
    public int slideCounter { set; get; }
    private int _lengthOfSlides;
    private List<byte[]> Slides { get; set; }

    public List<Texture2D> SlidesTextures { get; set; }
    
    public int sliderCounterAtOrigin {set; get; }

    public string sceneName;

    public PopupController popupController;

    // Start is called before the first frame update
    void Start()
    {
        Main = GameObject.FindWithTag("Main").GetComponent<Main>();
        Main.ActivateAccessoiresOnOrigin();
        Main.DeactivateRayInteractor();

        
        // sliderCounterAtOrigin = GameObject.FindWithTag("Counter").GetComponent<CounterForPresentationSlides>().SlideCounter;
        


        
        FileHandler = Main.FileHandler;

        _leinwandRenderer = GetComponent<Renderer>();
        Slides = FileHandler.LoadPresentation();
        slideCounter = 0;
        SlidesTextures = new List<Texture2D>();

        foreach (byte[] slide in Slides)
        {
            var slideTexture = new Texture2D(1, 1);
            slideTexture.LoadImage(slide);
            slideTexture.Apply();

            SlidesTextures.Add(slideTexture);
        }

        _lengthOfSlides = SlidesTextures.Count;
        _leinwandRenderer.material.mainTexture = SlidesTextures[slideCounter];

    }

    // public void Update()
    // {
    //     sliderCounterAtOrigin = GameObject.FindWithTag("Counter").GetComponent<CounterForPresentationSlides>().SlideCounter;
    //
    //     var differenceBetweenCounter = sliderCounterAtOrigin - _slideCounter;
    //     
    //     if (differenceBetweenCounter == 1)
    //     {
    //         _slideCounter++;
    //     }
    //     
    //     if (differenceBetweenCounter == -1)
    //     {
    //         _slideCounter--;
    //     }
    //
    //
    //     if (_slideCounter > _lengthOfSlides - 1)
    //     {
    //         _slideCounter = _lengthOfSlides - 1;
    //     }
    //
    //     if (_slideCounter < 0)
    //     {
    //         _slideCounter = 0;
    //     }
    //
    //     if (_slideCounter == _lengthOfSlides - 1)
    //     {
    //         AfterPresentation();
    //     }
    //     
    //     _leinwandRenderer.material.mainTexture = SlidesTextures[_slideCounter];
    //
    //
    // }

    public void AfterPresentation()
    {
        if (sceneName == "Tutorial")
        {
            SceneManager.LoadScene("Elevator");
        }

        if (sceneName == "Studio")
        {
            popupController.EndPresentation();
        }

    }
    
    

    public void NextSlide()
    {
        Debug.Log(_lengthOfSlides);
        if (slideCounter < _lengthOfSlides - 1)
        {
            slideCounter++;
            _leinwandRenderer.material.mainTexture = SlidesTextures[slideCounter];
        }
        else
        {
            AfterPresentation();
        }

    }

    public void PreviousSlide()
    {
        if (slideCounter > 0)
        {
            slideCounter--;
            _leinwandRenderer.material.mainTexture = SlidesTextures[slideCounter];
        }
    }
} 
