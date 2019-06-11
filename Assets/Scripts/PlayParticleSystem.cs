using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystem : MonoBehaviour {

    ParticleSystem PS;

	// Use this for initialization
	void Start () {
        PS = gameObject.GetComponent<ParticleSystem>();
        PS.Play();
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("Die", 1);
	}

    void Die() {
        Destroy(gameObject);
    }
}
