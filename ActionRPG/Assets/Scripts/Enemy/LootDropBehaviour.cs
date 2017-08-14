using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LootDropBehaviour : MonoBehaviour {

    //loot values
    public float healthRestore = 0.0f;
    public float manaRestore = 0.0f;

    //tween values
    [Header("Tween vars")]
    public float jumpPower = 1.0f; //jump power of tween
    public float duration = 0.5f; //duration of tween
    public bool snapping = false; //snap?
    public float distanceToJump = 1.0f; //distance to jump

	// Use this for initialization
	void Start () {
        Jump();
	}
	
	// Update is called once per frame
	void Update () {
		//debug
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    //makes the loot jump out
    private void Jump()
    {
        //get point slightly ahead of self
        Vector3 pointAhead = transform.forward * distanceToJump;
        Vector3 dropPoint = transform.position + pointAhead;
        //jump to target location
        transform.DOJump(dropPoint, jumpPower, 1, duration, snapping);
    }

    //when colliding with player
    private void OnCollisionEnter(Collision collision)
    {
        //if other is player
        if (collision.gameObject.CompareTag("Player"))
        {
            //pick it up and restore resources
            collision.gameObject.GetComponent<ResourceManagement>().HealHealth(healthRestore);
            collision.gameObject.GetComponent<ResourceManagement>().HealMana(manaRestore);
        }
    }
}
