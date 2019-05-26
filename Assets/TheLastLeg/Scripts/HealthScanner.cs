using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthScanner: MonoBehaviour
{

    public bool scanResult = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth.currentHP == 1)
            {
                Debug.Log("Scan Result = True");
                scanResult = true;                
            }
            else
            {
                Debug.Log("Scan Result = False");
                scanResult = false;
            }

        }
    }
}
