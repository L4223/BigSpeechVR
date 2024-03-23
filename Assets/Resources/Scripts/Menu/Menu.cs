using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace Menu
{
    using FileHandler;
    public class Menu : MonoBehaviour
    {
        private FileHandler FileHandler { get; set; }
        private GameObject ProjectionScreenPrefab { get; set;}
        private GameObject ProjectionScreen { get; set; }
        
        private Renderer ActualScreenPlay { get; set; }
        private Texture2D ActualSlide { get; set; }
        private Texture2D NextSlide { get; set; }
        private List<byte[]> Slides { get; set; }
        
        // Start is called before the first frame update
        void Start()
        {
            // Lade die Leinwand und den Renderer
            ProjectionScreenPrefab = Resources.Load("Prefabs/ProjectionScreen") as GameObject;
            ProjectionScreen = Instantiate(ProjectionScreenPrefab, new Vector3(0, 6, 0), Quaternion.Euler(90, 0, 180));
            ActualScreenPlay = ProjectionScreen.GetComponent<Renderer>();
            
            // Lade die Präsentation
            FileHandler = new FileHandler();
            // Slides = FileHandler.LoadPresentation("Willkommen bei PowerPoint");
            
            // Lade die Slides und die zeige Sie auf der Leinwand an
            ActualSlide = new Texture2D(1,1); // Höhe und Breite wird später überschrieben
            ActualSlide.LoadImage(Slides[4]);
            ActualSlide.Apply();
            ActualScreenPlay.material.mainTexture = ActualSlide;
            Debug.Log("Done");
            
        }

        // Update is called once per frame
        void Update()
        {
       
      
        }
    }
}
