using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EObstacleType
{
    SpeedUp,
    SlowDown,
    Stun,
    Health
}

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private EObstacleType _ObstacleType;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private PlayerMovement playerMovement;
    private Health playerHealth;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerHealth = FindObjectOfType<Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (_ObstacleType)
        {
            case EObstacleType.Health:
                {
                    playerHealth.HealDamage();
                    break;
                }
            case EObstacleType.SlowDown:
                {
                    playerHealth.DoDamage();
                    playerMovement.SetPlayerMovementSpeed(PlayerMovement.Speed.slow);
                    break;
                }
            case EObstacleType.SpeedUp:
                {
                    playerHealth.DoDamage();
                    playerMovement.SetPlayerMovementSpeed(PlayerMovement.Speed.fast);
                    break;
                }
            case EObstacleType.Stun:
                {
                    playerHealth.DoDamage();
                    playerMovement.SetPlayerMovementSpeed(PlayerMovement.Speed.slow);
                    break;
                }
        }

        Destroy(this.gameObject);
    }

    //Temporary to make the obstacles look different when the type is changed.
    private void OnValidate()
    {
        switch(_ObstacleType)
        {
            case EObstacleType.Health:
                {
                    spriteRenderer.color = Color.red;
                    break;
                }
            case EObstacleType.SlowDown:
                {
                    spriteRenderer.color = Color.yellow;
                    break;
                }
            case EObstacleType.SpeedUp:
                {
                    spriteRenderer.color = Color.green;
                    break;
                }
            case EObstacleType.Stun:
                {
                    spriteRenderer.color = Color.blue;
                    break;
                }
        }
    }
}
