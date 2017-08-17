using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour {

    public bool CanInteract = false;
    public bool LoadLevel = false;
    public bool progressFlag = false;
    public int SceneNumber = 0;

    //Interaction not triggering? Does the mouse manager exist?
    
    public void Interact()
    {
        if (CanInteract)
        {
            if (progressFlag)
            {
                TownProgression townProgression = GameObject.FindGameObjectWithTag("Manager").GetComponent<TownProgression>();
                if (townProgression.currentState == TownProgression.TownCurrentState.Starting)
                {
                    townProgression.currentState = TownProgression.TownCurrentState.Progressed;
                }
                else if(townProgression.currentState == TownProgression.TownCurrentState.Progressed)
                {
                    townProgression.currentState = TownProgression.TownCurrentState.Complete;
                }
            }
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