﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillTreeManager : MonoBehaviour {

    //script ref
    private SpellActivationBehaviour spellBehaviour;

    //buttons ref
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;
    public Button buttonFour;

    //button image ref
    public Image buttonOneImage;
    public Image buttonTwoImage;
    public Image buttonThreeImage;
    public Image buttonFourImage;

	// Use this for initialization
	void Start () {
        spellBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<SpellActivationBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //button logic for learning spells, and then make the button non interactable <- change the sprite?
    public void LearnSpellOne()
    {
        spellBehaviour.SpellOneLearned = true;
        buttonOne.interactable = false;
    }

    public void LearnSpellTwo()
    {
        spellBehaviour.SpellTwoLearned = true;
        buttonTwo.interactable = false;
    }

    public void LearnSpellThree()
    {
        spellBehaviour.SpellThreeLearned = true;
        buttonThree.interactable = false;
    }

    public void LearnSpellFour()
    {
        spellBehaviour.SpellFourLearned = true;
        buttonFour.interactable = false;
    }
}