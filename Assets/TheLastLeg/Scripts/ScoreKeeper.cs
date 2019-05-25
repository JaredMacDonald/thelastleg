using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    [SerializeField]
    GameObject playerObject;
    [SerializeField]
    Text scoreText;

    public int currentScore = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentScore = (int)Vector3.Distance(playerObject.transform.position, Vector3.zero);
        scoreText.text = currentScore.ToString();
	}
}
