using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Level[] Levels;
    public List<GameObject> ObstaclesHit;

    static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
