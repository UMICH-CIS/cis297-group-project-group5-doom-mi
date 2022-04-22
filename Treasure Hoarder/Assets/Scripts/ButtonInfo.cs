using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int WeaponID;
    public Text Price;
    public Text Quantity;
    public GameObject ItemShopManager;

    // Update is called once per frame
    void Update()
    {
        Price.text = "$" + ItemShopManager.GetComponent<ItemShopManagerScript>().ItemShop[2, WeaponID].ToString();
        Quantity.text = ItemShopManager.GetComponent<ItemShopManagerScript>().ItemShop[3, WeaponID].ToString();
    }
}
