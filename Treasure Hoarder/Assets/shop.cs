using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private bool isShopping = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isShopping == false)
            {
                notShopping();
            }
            else
            {
                Shopping();
            }
        }
    }

    void Shopping()
    {
        isShopping = true;
        Debug.Log("Pause");
        shopUI.SetActive(true);
        Time.timeScale = 0f;

    }

    public void notShopping()
    {
        isShopping = false;
        shopUI.SetActive(false);
        Time.timeScale = 1f;

        Debug.Log("resume");
    }

}
