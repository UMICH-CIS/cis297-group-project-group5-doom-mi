using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup(collision);
            FindObjectOfType<AudioManager>().Play("Coin Collect");
        }
    }

    private void Pickup(Collider2D player)
    {
        PlayerStats coins = player.GetComponent<PlayerStats>();
        coins.Tabloons += 1;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }
}
