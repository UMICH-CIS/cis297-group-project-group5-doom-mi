using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolSound : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<AudioManager>().Play("Pistol Attack");
        }
    }
}
