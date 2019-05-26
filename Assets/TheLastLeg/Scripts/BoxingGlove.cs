using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGlove : MonoBehaviour
{

    [SerializeField]
    Transform startGate;
    [SerializeField]
    HealthScanner healthScanner;

    private void Start()
    {
        if (!startGate)
        {
            startGate = GameObject.FindGameObjectWithTag("Start").transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (healthScanner.scanResult == false)
            {
                // TODO - shoot player off screen with boxing glove.  
                FindObjectOfType<PlayerMovement>().gameObject.transform.SetPositionAndRotation(startGate.position, Quaternion.identity);

                foreach(GameObject obj in GameManager.Instance.ObstaclesHit)
                {
                    obj.SetActive(true);
                }
            }
        }
    }
}
