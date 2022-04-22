using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float duration = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Pickup(collision));
            FindObjectOfType<AudioManager>().Play("Speed Boost");
        }
    }

    private IEnumerator Pickup(Collider2D player)
    {
        PlayerMovement speed = player.GetComponent<PlayerMovement>();
        speed.runSpeed += 3;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        speed.runSpeed -= 3;
        Destroy(gameObject);
    }
}

