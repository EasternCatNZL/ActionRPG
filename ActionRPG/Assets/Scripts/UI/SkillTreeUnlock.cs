using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeUnlock : MonoBehaviour {

    public Sprite LockedImage = null;
    public Sprite UnlockedImage = null;

    public SkillTreeUnlock Parent;

    private bool Unlocked = false;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().sprite = LockedImage;
    }

    public void ButtonPress()
    {
        if(!Unlocked)
        {
            if(Parent.isUnlocked())
            {
                GetComponent<Image>().sprite = UnlockedImage;
                Unlocked = true;
            }
        }
    }

    public bool isUnlocked()
    {
        return Unlocked;
    }
}
