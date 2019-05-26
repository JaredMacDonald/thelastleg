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
    float timeLeft;
    
	void Start () {
        //timeLeft = Level.TimeLimit;
	}
	
	// Update is called once per frame
	void Update () {
        currentScore = (int)Vector3.Distance(playerObject.transform.position, Vector3.zero);
        scoreText.text = currentScore.ToString();
        timeLeft -= Time.deltaTime;
    }

    public int CalculateLevelScore(int currentScore)
    {
        currentScore += (int)timeLeft;
        return currentScore;
    }



}
