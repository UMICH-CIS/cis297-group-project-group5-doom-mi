using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bringer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Collider2D col;
    private Collider2D colPlayer;
    public GameObject player;
    public float speed;

    private bool attacking;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        colPlayer = player.GetComponent<Collider2D>();
        attacking = false;
    }

    void Update()
    {
        //Debug.Log(gameObject.transform.position);
        if (col.IsTouching(colPlayer) && !attacking)
        {
            attacking = true;

            rb.velocity = new Vector2(0, 0);
            anim.Play("Bringer_Attacking");

            //anim.SetBool("Contact", true);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (attacking == false)
        {
            gameObject.transform.position = gameObject.transform.position + ((player.transform.position - gameObject.transform.position).normalized * speed * Time.fixedDeltaTime);
            if ((gameObject.transform.position - player.transform.position).x < 0)
            {
                gameObject.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }
}
