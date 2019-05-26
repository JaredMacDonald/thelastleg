using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGlove : MonoBehaviour
{

    [SerializeField]
    Transform startGate;
    [SerializeField]
    HealthScanner healthScanner;

    public bool startLerping = false;

    private void Start()
    {
        if (!startGate)
        {
            startGate = GameObject.FindGameObjectWithTag("Start").transform;
        }
    }


    private void Update()
    {
        if(startLerping)
        {
            LerpCamera(Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (healthScanner.scanResult == false)
            {
                // TODO - shoot player off screen with boxing glove.  
<<<<<<< HEAD
                PlayerMovement movement = FindObjectOfType<PlayerMovement>();
               movement.SetPlayerMovementSpeed(PlayerMovement.Speed.stunned);
               movement.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5000);
                FindObjectOfType<PlayerAnimation>().SetAnimation(PlayerAnimation.Animation.HurtNormal);
                StartCoroutine(WaitAndTeleport());
                Camera.main.transform.parent = null;
                startLerping = true;
                //FindObjectOfType<PlayerMovement>().gameObject.transform.SetPositionAndRotation(startGate.position, Quaternion.identity);
=======
                FindObjectOfType<PlayerMovement>().gameObject.transform.SetPositionAndRotation(startGate.position, Quaternion.identity);

                foreach(GameObject obj in GameManager.Instance.ObstaclesHit)
                {
                    obj.SetActive(true);
                }
>>>>>>> 65fdc3dde7b3730101617988756a428fd238046f
            }
        }
    }



    void LerpCamera(float delta)
    {
        float x = Mathf.Lerp(Camera.main.transform.position.x, startGate.transform.position.x, delta);
        float y = Mathf.Lerp(Camera.main.transform.position.y, startGate.transform.position.y + 2.5f, delta);

        Camera.main.transform.position = new Vector3(x, y, -10);
    }


    IEnumerator WaitAndTeleport()
    {
        yield return new WaitForSeconds(1);
        PlayerMovement movement = FindObjectOfType<PlayerMovement>();
        movement.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Vector3 teleportPosition = startGate.position + new Vector3(0, 100, 0);
        FindObjectOfType<PlayerMovement>().gameObject.transform.SetPositionAndRotation(teleportPosition, Quaternion.identity);
    }
}
