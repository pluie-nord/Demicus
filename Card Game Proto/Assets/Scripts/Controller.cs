using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float speed;
    public static float speedX;
    public static float speedY;
    //private Vector3 startScale;
    //public Animator animator;
    private bool isMoving = false;
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        //startScale = transform.localScale;
    }

    void Update()
    {
        isMoving = false;
        /*if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("WalkSideDown");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("WalkSideDown");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("WalkDown");
            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
            {
                animator.SetTrigger("WalkSideDown");
            }

        }*/
        if (Input.GetKey(KeyCode.A))
        {
            isMoving = true;
            speedX = -speed;
            //transform.localScale = new Vector3(startScale.x * (-1), startScale.y, startScale.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isMoving = true;
            speedX = speed;
            //transform.localScale = startScale;
        }
        if (Input.GetKey(KeyCode.S))
        {
            isMoving = true;
            speedY = -speed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            isMoving = true;
            speedY = speed;
        }
        /*if (Input.GetKey(KeyCode.LeftShift))
        {
            speedX *= runSpeed;
            speedY *= runSpeed;
        }*/
        transform.Translate(speedX, speedY, 0);
        speedX = 0;
        speedY = 0;
        /*if (!isMoving)
        {
            animator.SetBool("Idle", true);
        }
        else
        {
            animator.SetBool("Idle", false);
        }*/
    }
}
