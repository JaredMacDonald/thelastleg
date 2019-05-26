using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinishGate : MonoBehaviour
{

    [SerializeField]
    Transform startGate;

    [SerializeField]
    TextMeshProUGUI winPopUp;


    // Use this for initialization
    void Start()
    {
        if(!startGate)
        {
            startGate = GameObject.FindGameObjectWithTag("Start").transform;
        }
        if(!winPopUp)
        {
            winPopUp = FindObjectOfType<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth.currentHP == 1)
            {
                Debug.Log("You WIN!");
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetPlayerMovementSpeed(PlayerMovement.Speed.stunned);
                winPopUp.enabled = true;
            }
            else
            {
                playerHealth.gameObject.transform.SetPositionAndRotation(startGate.position, Quaternion.identity);
            }

        }
    }
}
