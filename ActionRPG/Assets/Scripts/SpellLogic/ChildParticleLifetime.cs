﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildParticleLifetime : MonoBehaviour {

    public AudioSource sound;

    ParticleSystem partsSystem;
    float particleDuration;

    // Use this for initialization
    void Start () {
        partsSystem = GetComponent<ParticleSystem>();
        if(!partsSystem)
            partsSystem = GetComponentInChildren<ParticleSystem>();
        particleDuration = partsSystem.main.duration + partsSystem.main.startLifetimeMultiplier;
        //startTime = Time.time;
        if (sound) sound.Play();
        Destroy(gameObject, particleDuration);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
