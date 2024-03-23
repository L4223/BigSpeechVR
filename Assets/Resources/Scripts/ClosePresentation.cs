using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosePresentation : MonoBehaviour
{
    public void SwitchToElevator()
    {
        GameObject main = GameObject.FindGameObjectWithTag("Main");

        if (main != null)
        {
            main.GetComponent<Main>().DeactivateAccessoiresOnOrigin();
        }
        else
        {
            Debug.LogError("Main object not found!");
        }
               
        SceneManager.LoadScene("Elevator");
    }
}
