using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ElevatorPrefab
{
    public class DropdownHandler : MonoBehaviour
    {
        public Main Main { set; get; }

        private List<string> _directories;
        public TMP_Dropdown dropdown;

        // Start is called before the first frame update
        void Start()
        {
            Main = GameObject.FindWithTag("Main").GetComponent<Main>();

            _directories = Main.FileHandler.ShowDirectories();

            dropdown.ClearOptions();


            foreach (var directory in _directories)
            {
                // Überprüfe, ob der Ordner "il2cpp" ist, und füge ihn nicht dem Dropdown-Menü hinzu
                if (directory != "il2cpp")
                {
                    dropdown.options.Add(new TMP_Dropdown.OptionData(directory) { text = directory });
                }
            }

            dropdown.RefreshShownValue();

            DropdownItemSelected(dropdown);

            dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
        }

        void DropdownItemSelected(TMP_Dropdown dropdown)
        {
            int index = dropdown.value;
            string directory = dropdown.options[index].text;
            Main.FileHandler.Directory = directory;
        }
    }
}