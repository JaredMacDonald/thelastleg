using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public enum Speed
    {
        normal = 0,
        slow,
        fast
    }


    public float normalSpeed = 0.1f;
    public float fastSpeed = 0.2f;
    public float slowSpeed = 0.05f;

    [SerializeField]
    Transform m_PlayerTranform;
    [SerializeField]
    Rigidbody2D m_playerRB;

    [SerializeField]
    float m_MovementSpeed = 0.1f;
    [SerializeField]
    float m_JumpForce= 250.0f;

    [SerializeField]
    BoxCollider2D m_StandingCollider;
    [SerializeField]
    BoxCollider2D m_DuckingCollider;

    bool isJumping = false;


    // Use this for initialization
    void Start () {
		
	}
   
	
	// Update is called once per frame
	void Update () {      
        m_PlayerTranform.Translate(Vector3.right * m_MovementSpeed);
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Duck();
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
            Debug.Log("You Landed!");
            isJumping = false;
        }
    }

    void Jump()
    {
        // TODO 's: 
        // set animation state to jumping.  
        // set isJumping to true
        // set hasLanded to false
        isJumping = true;
        m_StandingCollider.enabled = true;
        m_DuckingCollider.enabled = false;
        Debug.Log("You Jumped!");
        m_playerRB.AddForce(Vector2.up * m_JumpForce);
    }

    void Duck()
    {
        // set animation state to sliding.
        Debug.Log("You Ducked!");
        m_StandingCollider.enabled = false;
        m_DuckingCollider.enabled = true;
    }

    void Stand()
    {
        // set animation state to standing/running.
        Debug.Log("You stopped ducking.");
        m_StandingCollider.enabled = true;
        m_DuckingCollider.enabled = false;
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

        }
        return;
    }
}
