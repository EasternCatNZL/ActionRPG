using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActivationBehaviour : MonoBehaviour {

    //mouse target ref
    private MouseTarget mouseTarget;

    //bullet object
    [Header("Bullet objects")]
    public GameObject basicBullet;
    public GameObject biggerBullet;

    //indicator objects, displays on the ground
    [Header("Indicators")]
    public GameObject lineIndicator; //for line shots
    public GameObject circleIndicator; //for circle target shots

    private GameObject currentIndicatorRef; //reference to currently active indicator

    //control bools
    private bool isReadyingSpell; //checks if currently preparing spell
    private bool spellOnePreparing; //checks if spell is currently being prepared

    // Use this for initialization
    void Start () {
        mouseTarget = Camera.main.GetComponent<MouseTarget>();
    }
	
	// Update is called once per frame
	void Update () {
        //if ready to use spell, look for use input
        if (isReadyingSpell)
        {
            UseSpell();
        }
        //else, check for prep input
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FireBasicShot();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PrepareSpellOne();
            }
        }
		
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
        //set current indicator ref to this indicator
        currentIndicatorRef = indicatorClone;
        //get rotation from player to mouse pos
        mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = mouseTarget.mouseTargetPos - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //spawn the indicator into the world
        Instantiate(indicatorClone, mouseTarget.mouseTargetPos, rotationDirection);
    }

    //uses spell 1
    void UseSpellOne()
    {
        //turn preparing spell off
        isReadyingSpell = false;
        spellOnePreparing = false;
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

    //when pressing mouse left click to confirm spell usage
    void UseSpell()
    {
        //check for mouse left click input
        if (Input.GetMouseButtonDown(0))
        {
            //check for spells prepared
            if (spellOnePreparing)
            {
                UseSpellOne();
            }
        }
    }
}
