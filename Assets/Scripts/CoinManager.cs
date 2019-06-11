using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour {

    // Number of coins player has collected
    public int CoinsCollected = 0;

    // Count of all the coins in the level
    public int CoinCount = 0;

    // Stores all coins in level
    GameObject[] Coins;

    // Assign in inspector
    public Text CoinCountText;

    AudioSource ThisAudio;

    public AudioClip CollectSound;

	// Use this for initialization
	void Start () {
        // Get all the coins in the level
        Coins = GameObject.FindGameObjectsWithTag("Coin");

        // Count all the coins in the level
        foreach (GameObject C in Coins) {
            CoinCount++;
        }

        ThisAudio = gameObject.GetComponent<AudioSource>();
        ThisAudio.clip = CollectSound;

        CoinCountText.text = CoinsCollected.ToString() + "/" + CoinCount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddCoin(GameObject coin) {
        ThisAudio.Play();
        Destroy(coin);
        CoinsCollected++;
        CoinCountText.text = CoinsCollected.ToString() + "/" + CoinCount.ToString();
    }
}
