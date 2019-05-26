using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FinishLine : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI winPopUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You WIN!");
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().SetPlayerMovementSpeed(PlayerMovement.Speed.stunned);
            winPopUp.enabled = true;
        }
    }
}
