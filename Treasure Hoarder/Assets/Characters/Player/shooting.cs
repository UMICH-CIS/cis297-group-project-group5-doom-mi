using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform firepoint;
    public Transform firepoint1;
    public Transform firepoint2;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public float bulletForce = 10f;
    public PlayerMovement player;


    private bool pistol = true;
    
    public bool shotgun = false; 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol = true;
            shotgun = false; 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pistol = false;
            shotgun = true; 
        }
        
    }
    private void Shoot()
    {
        if (pistol) {
            //pistol 
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5.0f);
        }

        if (shotgun)
        {
            //shotgun 
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            GameObject shotgunbullet = Instantiate(bulletPrefab1, firepoint1.position, firepoint1.rotation);
            GameObject shotgunbullet1 = Instantiate(bulletPrefab2, firepoint2.position, firepoint2.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Rigidbody2D rb1 = shotgunbullet.GetComponent<Rigidbody2D>();
            Rigidbody2D rb2 = shotgunbullet1.GetComponent<Rigidbody2D>();

            rb1.AddForce(firepoint1.up * bulletForce, ForceMode2D.Impulse);
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            rb2.AddForce(firepoint2.up * bulletForce, ForceMode2D.Impulse);

            Destroy(bullet, 5f);
            Destroy(shotgunbullet, 5f);
            Destroy(shotgunbullet1, 5f);

        }








    }
}
    






       


            
        


