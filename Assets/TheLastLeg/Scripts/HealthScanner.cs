using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthScanner: MonoBehaviour
{

    [SerializeField]
    ResultScreen results;

    public bool scanResult = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            results.spriteRenderer.sprite = results.sprites[(int)ResultScreen.ResultStatus.processing];
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (scanResult)
        {
            results.spriteRenderer.sprite = results.sprites[(int)ResultScreen.ResultStatus.clear];
        }
        else
        {
            results.spriteRenderer.sprite = results.sprites[(int)ResultScreen.ResultStatus.tooMuchHealth];
        }
    }
}
