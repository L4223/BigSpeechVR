using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FileHandler
{
    public class FileHandler
    {
        /**Pfad zu den Dateien = C:/Users/jleus/AppData/LocalLow/AVR_Lasse_Jason/PresentationVR*
         */
        private string _directoryPath;

        public string DirectoryPath
        {
            get => _directoryPath;
            set => _directoryPath = value;
        }
        
        public string Directory { set; get; }

        // Konstrukter der dem DirectoryPath den Pfad zu den Dateien zuweist
        public FileHandler()
        {
            DirectoryPath = Application.persistentDataPath;
            Debug.Log(DirectoryPath);
        }

        // Gibt eine String-Liste mit den Namen der Ordner im GameData-Ordner zurück
        public List<string> ShowDirectories()
        {
            List<string> directories = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath);

            foreach (var directory in directoryInfo.GetDirectories())
            {
                Debug.Log(directory.Name);
                directories.Add(directory.Name);
            }

            return directories;
        }

        // Lädt die BitDaten der einzelen PNGs in eine Liste
        public List<byte[]> LoadPresentation()
        {
            List<byte[]> presentation = new List<byte[]>();
            
            if (Directory != null)
            {


                DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryPath + "/" + Directory);
                
                foreach (var png in directoryInfo.GetFiles("*.png"))
                {
                    byte[] bytes = File.ReadAllBytes(DirectoryPath + "/" + Directory + "/" + png.Name);
                    presentation.Add(bytes);
                }
            }
            else
            {
                {
                    Debug.LogError("Directory is null");
                    presentation = null;
                }
            }


            
            
            return presentation;
        }
        
    }
}