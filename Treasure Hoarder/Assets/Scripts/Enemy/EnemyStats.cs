using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float Health = 100;
    public GameObject moneyDrop;
    public List<Transform> items = new List<Transform>();
    public float Damage = 5;

    public void Update()
    {
        if (Health == 0)
        {
            OnDestroy(); 
        }
    }
    private void OnDestroy()
    {
        Instantiate(moneyDrop, transform.position, Quaternion.identity);
        int randomNumber = Random.Range(0, 30);
        if (randomNumber == 13)
        {
            Instantiate(items[Random.Range(0, items.Count - 1)], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")//or tag
        {
            TakeDamage(20);
            FindObjectOfType<AudioManager>().Play("Enemy Hit");
        }
    }

    void TakeDamage(int damage)
    {
        Health -= damage; 
    }
}
