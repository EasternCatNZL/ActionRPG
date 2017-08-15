using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour {

    public bool LoadLevel = false;
    public int SceneNumber = 0;

    public void Interact()
    {
        if(LoadLevel)
        {
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
