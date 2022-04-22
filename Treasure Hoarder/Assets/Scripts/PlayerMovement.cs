using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public Vector2 movement;
    public Animator animator;

    //Screen Bounds Object
    public ScreenBounds screenBounds;


    private float moveLimiter = 0.7f;

    public float runSpeed;
    private float timeStamp = 1f;
    public float cooldownperiod = 1f;
    private bool Dashing;


    //shooting variables 
    public Camera cam;
    private Vector2 mousepos; 
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Screen Bounds attributes to allow for screen wrapping and boundries for the player

        mousepos = cam.ScreenToWorldPoint(Input.mousePosition); 
        // Gives a value between -1 and 1
        movement.x = Input.GetAxisRaw("Horizontal"); // -1 is left
        movement.y = Input.GetAxisRaw("Vertical"); // -1 is down
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if (timeStamp <= Time.time) //attach a cooldown timer for the dash 
        {

            if (Input.GetKeyDown(KeyCode.LeftShift)) //allows the player to dash 
            {
                Dashing = true;
                timeStamp = Time.time + cooldownperiod;
            }
            
        }
    }

    void FixedUpdate()
    {
        //shooting
        Vector3 p = cam.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;
        Debug.Log(p); 
        if(p.x < 0)
        {
            animator.Play("Player_Walk_Left"); 
        }else if(p.x > 0)
        {
            animator.Play("Player_Walk_Right");
        }
        // Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // v -= transform.position;
        // v.z = 0;
        //transform.up = v;

        //Vector2 lookDir = mousepos - body.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f * Time.deltaTime;
        //body.rotation = angle;

        if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            movement.x *= moveLimiter;
            movement.y *= moveLimiter;
        }

        body.velocity = new Vector2(movement.x * runSpeed, movement.y * runSpeed);

        if (Dashing)
        {
            float dashAmount = 1f;
            body.MovePosition(body.position + movement * dashAmount); //allows the player to dash by having its postion add the movemnt * dash power
            Dashing = false;
        }
    }
}
