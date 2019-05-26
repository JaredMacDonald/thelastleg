using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Pickup : MonoBehaviour {

    Health playerHP;

    private void Start()
    {
        playerHP = FindObjectOfType<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHP.HealDamage();
        gameObject.SetActive(false);

        GameManager.Instance.ObstaclesHit.Add(gameObject);
    }

}
