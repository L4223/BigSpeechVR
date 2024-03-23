using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountAehms : MonoBehaviour
{

    private TMP_Text _text;

    private int counter;
    private int sentencesCounter;

    public int Aehms{ get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TMP_Text>();
        counter = 0;
        sentencesCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Aehms = sentencesCounter - counter;
        _text.text = "Anzahl Füllwörter: " + (sentencesCounter - counter);
    }

    public void CountAehmsNow()
    {
        counter++;
    }
    
    public void CountAehmsReallyNow()
    {
        sentencesCounter++;
    }
}
