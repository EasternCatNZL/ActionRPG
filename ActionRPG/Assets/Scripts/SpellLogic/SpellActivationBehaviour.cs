using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellActivationBehaviour : MonoBehaviour {

    //mouse target ref
    private MouseTarget mouseTarget;

    //bullet object
    [Header("Spell objects")]
    public GameObject basicBullet;
    public GameObject Shockwave;
    public GameObject PushOut;
    public GameObject GravityLift;
    public GameObject DonutSpell;

    ////indicator objects, displays on the ground
    //[Header("Indicators")]
    //public GameObject lineIndicator; //for line shots
    //public GameObject circleIndicator; //for circle target shots

    //have learnt spells
    [HideInInspector]
    public bool SpellOneLearned = false;
    [HideInInspector]
    public bool SpellTwoLearned = false;
    [HideInInspector]
    public bool SpellThreeLearned = false;
    [HideInInspector]
    public bool SpellFourLearned = false;

    // Use this for initialization
    void Start () {
        mouseTarget = Camera.main.GetComponent<MouseTarget>();
    }
	
	// Update is called once per frame
	void Update () {
        UseSpell();
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
            UseShockwave();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //PrepareSpellTwo();
            UsePushOut();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //PrepareSpellThree();
            UseGravityDrop();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            UseDonutSpell();
        }
    }

    //fire basic shot in the direction of the mouse in world
    void FireBasicShot()
    {
        //get the direction of mouse from self
        //mouseTarget.GetWorldMousePos();
        Vector3 directionToFire = MouseTarget.GetWorldMousePos() - transform.position;
        Quaternion rotationDirection = new Quaternion();
        rotationDirection = Quaternion.LookRotation(directionToFire);
        //rotationDirection.eulerAngles = directionToFire;
        //create a shot and fire it
        GameObject bulletClone = basicBullet;
        Instantiate(bulletClone, transform.position + new Vector3(0f, 0.5f, 0f), rotationDirection);
    }

    ///use spell two - pull in
    void UseShockwave()
    {
        //create spell and fire it
        GameObject spellClone = Shockwave;
        //spawn into the world
        Instantiate(spellClone, MouseTarget.GetWorldMousePos(), Quaternion.identity);
    }

    //use spell three - push away
    void UsePushOut()
    {
        //create spell and fire it
        GameObject spellClone = PushOut;
        //spawn into the world
        Instantiate(spellClone, MouseTarget.GetWorldMousePos(), Quaternion.identity);
    }

    //use spell four - lift and drop
    void UseGravityDrop()
    {
        //create spell and fire it
        GameObject spellClone = GravityLift;
        //spawn into the world
        Instantiate(spellClone, MouseTarget.GetWorldMousePos(), Quaternion.identity);
    }

    //use spell five - gravity well draw in
    void UseDonutSpell()
    {
        //create spell and fire it
        GameObject spellClone = DonutSpell;
        //spawn into the world
        Instantiate(spellClone, transform.position, transform.rotation);
    }


}
