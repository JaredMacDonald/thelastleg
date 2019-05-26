using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public enum Speed
    {
        normal = 0,
        slow,
        fast,
        stunned
    }
    public float normalSpeed = 0.1f;
    public float fastSpeed = 0.2f;
    public float slowSpeed = 0.05f;


    // ====================== PHYSICS =======================
    [SerializeField]
    Transform m_PlayerTranform;
    [SerializeField]
    Rigidbody2D m_playerRB;

    [SerializeField]
    BoxCollider2D m_StandingCollider;
    [SerializeField]
    BoxCollider2D m_SlidingCollider;
    // ====================== PHYSICS =======================

    // ====================== DATA MEMBERS =======================
    [SerializeField]
    float m_MovementSpeed = 0.1f;
    [SerializeField]
    float m_JumpForce = 250.0f;
    bool isJumping = false;
    bool isSliding = false;

    [SerializeField]
    private float StunCooldown = 2.0f;

    private bool IsStunned = false;
    // ====================== DATA MEMBERS =======================

    // ====================== SCRIPTS =======================
    [SerializeField]
    Health m_Health;

    [SerializeField]
    PlayerAnimation m_Animator;

    [SerializeField]
    BoxingGlove boxingGlove;
    // ====================== SCRIPTS =======================


    private EObstacleType currentObstacleType;
    void Start()
    {
        m_SlidingCollider.enabled = false;
        m_StandingCollider.enabled = true;
    }


    void Update()
    {
        if (IsStunned)
        {
            return;
        }

        m_PlayerTranform.Translate(Vector3.right * m_MovementSpeed);
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            Jump();
        }
        isSliding = Input.GetKey(KeyCode.S);
        if (isSliding)
        {
            Slide();

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Stand();
        }
        Debug.Log("Is Jumping = " + isJumping);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && !isSliding)
        {
            if (Camera.main.transform.parent == null)
            {
                StartCoroutine(WaitASec());

            }
            else
            {                m_Animator.SetAnimation(PlayerAnimation.Animation.Run);
                isJumping = false;

            }
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            // Set animation state based on the type of the obstacle (Collision.GameObject.GetComponent<Obstacle>().type)
            EObstacleType obstacleType = collision.gameObject.GetComponent<Obstacle>().ObstacleType;
            if (obstacleType != EObstacleType.Health)
            {
                OnObstacleHit(obstacleType);
            }

            Debug.Log("You hit an obstacle!");
            //m_Health.DoDamage();
        }
    }

    void Jump()
    {
        m_Animator.SetAnimation(PlayerAnimation.Animation.Jump);
        isJumping = true;
        m_StandingCollider.enabled = true;
        m_SlidingCollider.enabled = false;
        Debug.Log("You Jumped!");
        m_playerRB.AddForce(Vector2.up * m_JumpForce);
    }

    void Slide()
    {
        // set animation state to sliding.
        m_Animator.SetAnimation(PlayerAnimation.Animation.Slide);
        Debug.Log("You slid!");
        m_StandingCollider.enabled = false;
        m_SlidingCollider.enabled = true;
    }

    void Stand()
    {
        // set animation state to standing/running.
        m_Animator.SetAnimation(PlayerAnimation.Animation.Run);
        Debug.Log("You stopped ducking.");
        m_StandingCollider.enabled = true;
        m_SlidingCollider.enabled = false;
    }

    public void SetPlayerMovementSpeed(Speed speed)
    {
        switch (speed)
        {
            case Speed.normal:
                m_MovementSpeed = normalSpeed;
                break;
            case Speed.fast:
                m_MovementSpeed = fastSpeed;
                break;
            case Speed.slow:
                m_MovementSpeed = slowSpeed;
                break;
            case Speed.stunned:
                m_MovementSpeed = 0;
                break;

        }
        return;
    }

    void OnObstacleHit(EObstacleType obstacleType)
    {
        StartCoroutine(UpdateAnimation(obstacleType));
    }

    IEnumerator UpdateAnimation(EObstacleType obstacleType)
    {
        switch (obstacleType)
        {
            //Electric
            case EObstacleType.SpeedUp:
                {
                    IsStunned = true;
                    m_Animator.SetAnimation(PlayerAnimation.Animation.HurtFire);
                    AudioManager.Instance.PlaySound("FireIgnite");
                    break;
                }
            case EObstacleType.SlowDown:
                {
                    IsStunned = true;
                    m_Animator.SetAnimation(PlayerAnimation.Animation.HurtElectric);
                    AudioManager.Instance.PlaySound("ElectricShock");
                    break;
                }
            case EObstacleType.Stun:
                {
                    IsStunned = true;
                    m_Animator.SetAnimation(PlayerAnimation.Animation.HurtNormal);
                    SetPlayerMovementSpeed(Speed.normal);
                    break;
                }
        }

        yield return new WaitForSeconds(StunCooldown);

        m_Animator.SetAnimation(PlayerAnimation.Animation.Run);
        IsStunned = false;
    }


    IEnumerator WaitASec()
    {
        FindObjectOfType<ResultScreen>().SetSprite(0);
        m_Animator.SetAnimation(PlayerAnimation.Animation.Slide);
        yield return new WaitForSeconds(0.5f);
        Camera.main.transform.parent = gameObject.transform;
        Camera.main.transform.position = gameObject.transform.position + new Vector3(0f, 2.5f, -10f);
        boxingGlove.startLerping = false;        
        m_Animator.SetAnimation(PlayerAnimation.Animation.Run);
        SetPlayerMovementSpeed(PlayerMovement.Speed.normal);
        isJumping = false;
    }
}
