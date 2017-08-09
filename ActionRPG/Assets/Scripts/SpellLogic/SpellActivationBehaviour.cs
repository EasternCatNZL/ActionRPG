using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActivationBehaviour : MonoBehaviour {

    //mouse target ref
    private MouseTarget mouseTarget;

    //bullet object
    [Header("Spell objects")]
    public GameObject basicBullet;
    public GameObject biggerBullet;
    public GameObject spellTwo;
    public GameObject spellThree;
    public GameObject spellFour;

    ////indicator objects, displays on the ground
    //[Header("Indicators")]
    //public GameObject lineIndicator; //for line shots
    //public GameObject circleIndicator; //for circle target shots

    //control bools
    private bool isReadyingSpell; //checks if currently preparing spell
    //checks if spell is currently being prepared
    private bool spellOnePreparing; 
    private bool spellTwoPreparing;
    private bool spellThreePreparing;

    // Use this for initialization
    void Start () {
        mouseTarget = Camera.main.GetComponent<MouseTarget>();
    }
	
	// Update is called once per frame
	void Update () {
        UseSpell();
	}

    //fire basic shot in the direction of the mouse in world
    void FireBasicShot()
    {
        //get the direction of mouse from self
        mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = mouseTarget.mouseTargetPos - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //rotationDirection.eulerAngles = directionToFire;
        //create a shot and fire it
        GameObject bulletClone = basicBullet;
        Instantiate(bulletClone, transform.position, rotationDirection);
    }

    /*
    //prepares to fire spell 1
    void PrepareSpellOne()
    {
        //change control bools to true
        isReadyingSpell = true;
        spellOnePreparing = true;
        //create a clone of the indicator object
        GameObject indicatorClone = lineIndicator;
        //set clones player ref to this
        indicatorClone.GetComponent<IndicatorBehaviour>().player = this.gameObject;
        //get rotation from player to mouse pos
        mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = mouseTarget.mouseTargetPos - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //spawn the indicator into the world
        Instantiate(indicatorClone, mouseTarget.mouseTargetPos, rotationDirection);
    }
    */

    //uses spell 1 - big shot
    void UseSpellOne()
    {
        //get the direction of mouse from self
        mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = mouseTarget.mouseTargetPos - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //rotationDirection.eulerAngles = directionToFire;
        //create a shot and fire it
        GameObject bulletClone = biggerBullet;
        //spawn into the world
        Instantiate(bulletClone, transform.position, rotationDirection);
    }

    /*
    //prepare spell 2
    void PrepareSpellTwo()
    {
        //change control bools to true
        isReadyingSpell = true;
        spellTwoPreparing = true;
        //create a clone of the indicator object
        GameObject indicatorClone = circleIndicator;
        //set clones player ref to this
        indicatorClone.GetComponent<IndicatorBehaviour>().player = this.gameObject;
        //get rotation from player to mouse pos
        mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = mouseTarget.mouseTargetPos - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //spawn the indicator into the world
        Instantiate(indicatorClone, mouseTarget.mouseTargetPos, rotationDirection);
    }
    */

    //use spell two - pull in
    void UseSpellTwo()
    {
        //get the location of target
        mouseTarget.GetWorldMousePos();
        //create spell and fire it
        GameObject spellClone = spellTwo;
        //spawn into the world
        Instantiate(spellClone, mouseTarget.mouseTargetPos, Quaternion.identity);
    }

    /*
    //prepare spell 3
    void PrepareSpellThree()
    {
        //change control bools to true
        isReadyingSpell = true;
        spellThreePreparing = true;
        //create a clone of the indicator object
        GameObject indicatorClone = circleIndicator;
        //set clones player ref to this
        indicatorClone.GetComponent<IndicatorBehaviour>().player = this.gameObject;
        //get rotation from player to mouse pos
        mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = mouseTarget.mouseTargetPos - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //spawn the indicator into the world
        Instantiate(indicatorClone, mouseTarget.mouseTargetPos, rotationDirection);
    }
    */

    //use spell three - push away
    void UseSpellThree()
    {
        //get the location of target
        mouseTarget.GetWorldMousePos();
        //create spell and fire it
        GameObject spellClone = spellThree;
        //spawn into the world
        Instantiate(spellClone, mouseTarget.mouseTargetPos, Quaternion.identity);
    }

    //use spell four - lift and drop
    void UseSpellFour()
    {
        //get the location of target
        mouseTarget.GetWorldMousePos();
        //create spell and fire it
        GameObject spellClone = spellFour;
        //spawn into the world
        Instantiate(spellClone, mouseTarget.mouseTargetPos, Quaternion.identity);
    }

    //when pressing keyboard keys, use spell
    void UseSpell()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FireBasicShot();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            //PrepareSpellOne();
            UseSpellOne();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //PrepareSpellTwo();
            UseSpellTwo();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //PrepareSpellThree();
            UseSpellThree();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            UseSpellFour();
        }
    }

    ////when pressing mouse left click to confirm spell usage
    //void UseSpell()
    //{
    //    //check for mouse left click input
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //check for spells prepared
    //        if (spellOnePreparing)
    //        {
    //            UseSpellOne();
    //        }
    //        else if (spellTwoPreparing)
    //        {
    //            UseSpellTwo();
    //        }
    //        else if (spellThreePreparing)
    //        {
    //            UseSpellThree();
    //        }
    //    }
    //}
}
