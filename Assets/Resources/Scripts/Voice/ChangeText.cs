using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Oculus.Voice;
using TMPro;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [Header(("Voice"))]
    [SerializeField]
    private AppVoiceExperience _appVoiceExperience;

    private bool appVoiceActive;
    public List<string> savedText = new List<string>();


    private TMP_Text _text;
    private int _counter;
    
    // Start is called before the first frame update
    void Start()
    {
           _text = GetComponent<TMP_Text>();
           _counter = 0;
           // _appVoiceExperience.AudioEvents.ToString() =>
           // {
           //     _text.text = transcription;
           // });
           ActivateVoice();
    }

    // Update is called once per frame
    void Update()
    {
        _counter++;
        // _text.text = _counter.ToString();

        if (!_appVoiceExperience.Active)
        {
            ActivateVoice();
            _text.color = Color.white;
            // _text.text = "Voice is not active";
        }
        // _text.text = _appVoiceExperience.VoiceEvents.OnPartialTranscription 
        // if (_counter % 1000 == 0)
        // {
        //     ActivateVoice();
        // }
    }
    
    void ActivateVoice()
    {
        _appVoiceExperience.Activate();
        _appVoiceExperience.VoiceEvents.OnPartialTranscription.AddListener(OnListenerStart);
    }

    void OnListenerStart(string text)
    {
        savedText.Add(text);
        _text.text = text;
    }



    public void TextBlue()
    {
        _text.color = Color.blue;
    }

    public void OnApplicationQuit()
    {
        _appVoiceExperience.VoiceEvents.OnPartialTranscription.RemoveListener(OnListenerStart);
    }
    
    
}
