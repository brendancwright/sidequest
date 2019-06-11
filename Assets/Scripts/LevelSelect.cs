using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour {

    // Scene name
    public string Level = null;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void GoToLevel() {
        Application.LoadLevel(Level);
    }
}
