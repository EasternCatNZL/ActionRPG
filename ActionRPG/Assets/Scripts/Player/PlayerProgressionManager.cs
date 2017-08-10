using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgressionManager : MonoBehaviour {

    //script ref
    private PlayerSkillTreeManager skillTreeManager;

    [Header("Level management vars")]
    public int startingLevel = 1; //the starting level
    public int maxLevel = 10; //max level of the player
    public int unlockSpellTwoLevel = 2; //unlocks spell two
    public int unlockSpellThreeLevel = 4; //unlocks spell three
    public int unlockSpellFourLevel = 7; //unlocks spell four
    public float expBase = 100.0f; //the base amount of exp needed per level, scaled by amount
    public float expPerLevelScale = 1.1f; //the amount the required exp is scaled per level
    public float expIncreasePerLevel = 50.0f; //flat amount of exp required increase per level


    private int currentLevel = 1; //current level of the player
    private float currentExp = 0.0f; //current exp the player has
    private float requiredExp = 100.0f; //the required 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //increase the amount of exp player currently holds
    public void IncreaseExp(float exp)
    {
        currentExp += exp;
        LevelUp();
    }

    //level up logic
    private void LevelUp()
    {
        //if current exp is higher than required exp for the current level
        if (currentExp >= requiredExp)
        {
            //increase level by one
            currentLevel++;
            //get the excess exp
            float excessExp = currentExp - requiredExp;
            //reset current exp to zero + the excess
            currentExp = 0 + excessExp;
            //set new required exp for next level
            SetNextRequiredExp();
            //check to unlock new skills
            UnlockSkills();
        }
    }

    //get the amount of exp needed for the next level
    private void SetNextRequiredExp()
    {
        //flat amount for now
        requiredExp += expIncreasePerLevel;



        //increase using exponential algorithm
    }

    //open up skills upon level ups
    private void UnlockSkills()
    {
        //check at different levels, to unlock skills <- makes buttons interactable
        if (currentLevel == unlockSpellTwoLevel)
        {
            skillTreeManager.buttonTwo.interactable = true;
        }
        if (currentLevel == unlockSpellThreeLevel)
        {
            skillTreeManager.buttonThree.interactable = true;
        }
        if (currentLevel == unlockSpellFourLevel)
        {
            skillTreeManager.buttonFour.interactable = true;
        }
    }
}
