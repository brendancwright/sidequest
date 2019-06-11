using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

	// Scene name
	public string Level = null;

    BoxCollider2D ThisCollider;

	// Use this for initialization
	void Start () {
        ThisCollider = GetComponent<BoxCollider2D>();
        ThisCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
            // Load scene
            GoToLevel();
		}
	}

    void GoToLevel() {
        Debug.Log(QuestManager.GetQuestStatus("CollectCoins"));
        QuestManager.SetQuestStatus("CollectCoins", Quest.QUESTSTATUS.UNASSIGNED);
        Debug.Log(QuestManager.GetQuestStatus("CollectCoins"));
        Application.LoadLevel(Level);
    }
}
