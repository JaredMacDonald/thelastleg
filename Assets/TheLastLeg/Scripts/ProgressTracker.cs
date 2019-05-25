using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressTracker : MonoBehaviour {

    
    Transform start;
    Transform end;
    Transform playerPosition;

    float percentageComplete = 0;

    [SerializeField]
    Text progressText;
    [SerializeField]
    Slider progressBar;


	// Use this for initialization
	void Start () {
        start = GameObject.FindGameObjectWithTag("Start").transform;
        end = GameObject.FindGameObjectWithTag("End").transform;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        CalculateProgress();
	}

    void CalculateProgress()
    {
        int progressValue = (int)((playerPosition.position.x - start.position.x) / ((end.position.x -0.75) - start.position.x) * 100);
        progressText.text = progressValue.ToString();
        progressBar.value = progressValue;
    }
}
