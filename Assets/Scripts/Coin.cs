using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    // Assign in inspector
    public CoinManager CoinManager;

    public ParticleSystem EffectOnDestroy;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Instantiate(EffectOnDestroy, transform.position, transform.rotation);
            CoinManager.AddCoin(gameObject);
        }
    }
}
