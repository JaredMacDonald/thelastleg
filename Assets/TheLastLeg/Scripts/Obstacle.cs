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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
        switch (_ObstacleType)
        {
            case EObstacleType.Health:
                {
                    // Add Health to player
                    // player.AddHealth();
                    break;
                }
            case EObstacleType.SlowDown:
                {
                    // player.RemoveHealth();
                    playerMovement.SetPlayerMovementSpeed(PlayerMovement.Speed.slow);
                    break;
                }
            case EObstacleType.SpeedUp:
                {
                    // player.RemoveHealth();
                    playerMovement.SetPlayerMovementSpeed(PlayerMovement.Speed.fast);
                    break;
                }
            case EObstacleType.Stun:
                {
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
