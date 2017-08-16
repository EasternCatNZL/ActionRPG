using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour {

    public bool CanInteract = false;
    public bool LoadLevel = false;
    public int SceneNumber = 0;

 

    public void Interact()
    {
        if (CanInteract)
        {
            if (LoadLevel)
            {
                SceneManager.LoadScene(SceneNumber);
            }
        }
    }

    //Play activation animations and set CanInteract to true
    public void Activate()
    {
        CanInteract = true;
        GetComponent<Animator>().SetBool("Activated", true);
    }
}
