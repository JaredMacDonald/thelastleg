using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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

    // ====================== SPRITES =======================
    [SerializeField]
    Sprite m_StandingSprite;
    [SerializeField]
    Sprite m_SlidingSprite;
    [SerializeField]
    Sprite m_JumpingSprite;
    // ====================== SPRITES =======================


    // ====================== DATA MEMBERS =======================
    [SerializeField]
    float m_MovementSpeed = 0.1f;
    [SerializeField]
    float m_JumpForce= 250.0f;
    bool isJumping = false;
    // ====================== DATA MEMBERS =======================

    // ====================== SCRIPTS =======================
    Health m_Health;
    PlayerAnimation m_Animator;
    // ====================== SCRIPTS =======================


    void Start ()
    {
		m_SlidingCollider.enabled = false;
        m_StandingCollider.enabled = true;
	}
   

	void Update () {      
        m_PlayerTranform.Translate(Vector3.right * m_MovementSpeed);
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S))
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
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
        else if(collision.gameObject.tag == "Obstacle")
        {
            // Set animation state based on the type of the obstacle (Collision.GameObject.GetComponent<Obstacle>().type)
            //PlayerAnimation.Animation obstacleType = collision.gameObject.GetComponent<Obstacle>().type;
            //switch (obstacleType)
            {
                ////Electric
                //case Obstacle.ObstacleType.Fire:
                //    m_Animator.SetAnimation(PlayerAnimation.Animation.HurtFire);
                //    break;
                //case Obstacle.ObstacleType.Electric:
                //    m_Animator.SetAnimation(PlayerAnimation.Animation.HurtElectric);
                //    break;
                //case Obstacle.ObstacleType.Normal:
                //    m_Animator.SetAnimation(PlayerAnimation.Animation.HurtNormal);
                //    break;
                    //Fire
                    //Normal
            }
            Debug.Log("You hit an obstacle!");
            m_Health.DoDamage();
        }
    }

    void Jump()
    {
        //m_Animator.SetAnimation(PlayerAnimation.Animation.Jump);
        GetComponent<SpriteRenderer>().sprite = m_JumpingSprite;
        isJumping = true;
        m_StandingCollider.enabled = true;
        m_SlidingCollider.enabled = false;
        Debug.Log("You Jumped!");
        m_playerRB.AddForce(Vector2.up * m_JumpForce);
    }

    void Slide()
    {
        //m_Animator.SetAnimation(PlayerAnimation.Animation.Slide);
        // set animation state to sliding.
        GetComponent<SpriteRenderer>().sprite = m_SlidingSprite;
        Debug.Log("You slid!");
        m_StandingCollider.enabled = false;
        m_SlidingCollider.enabled = true;
    }

    void Stand()
    {
        //m_Animator.SetAnimation(PlayerAnimation.Animation.Run);
        GetComponent<SpriteRenderer>().sprite = m_StandingSprite;
        // set animation state to standing/running.
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
}
