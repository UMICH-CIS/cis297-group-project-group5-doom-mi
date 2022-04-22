using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemShopManagerScript : MonoBehaviour
{
    public int[,] ItemShop = new int[6, 6];
    public float GameMoney;
    public Text Players_Money;
    public PlayerMovement player;

    void Start()
    {
        //Weapon ID
        Players_Money.text = GameMoney.ToString();
        ItemShop[1, 0] = 1;
        ItemShop[1, 1] = 2;
        ItemShop[1, 2] = 3;
        ItemShop[1, 3] = 4;
        ItemShop[1, 4] = 5;
        ItemShop[1, 5] = 6;

        //Game Price
        ItemShop[2, 0] = 15;
        ItemShop[2, 1] = 10;
        ItemShop[2, 2] = 10;
        ItemShop[2, 3] = 30;
        ItemShop[2, 4] = 20;
        ItemShop[2, 5] = 50;

        //Game Quantity
        ItemShop[3, 0] = 0;
        ItemShop[3, 1] = 0;
        ItemShop[3, 2] = 0;
        ItemShop[3, 3] = 0;
        ItemShop[3, 4] = 0;
        ItemShop[3, 5] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (GameMoney >= ItemShop[2, ButtonRef.GetComponent<ButtonInfo>().WeaponID])
        {
            GameMoney -= ItemShop[2, ButtonRef.GetComponent<ButtonInfo>().WeaponID];
            ItemShop[3, ButtonRef.GetComponent<ButtonInfo>().WeaponID]++;
            Players_Money.text = GameMoney.ToString();
            ButtonRef.GetComponent<ButtonInfo>().Quantity.text = ItemShop[3, ButtonRef.GetComponent<ButtonInfo>().WeaponID].ToString();
        }
    }
    public void Buy_SpeedBoost()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (GameMoney >= ItemShop[2, ButtonRef.GetComponent<ButtonInfo>().WeaponID])
        {
            GameMoney -= ItemShop[2, ButtonRef.GetComponent<ButtonInfo>().WeaponID];
            ItemShop[3, ButtonRef.GetComponent<ButtonInfo>().WeaponID]++;
            Players_Money.text = GameMoney.ToString();
            ButtonRef.GetComponent<ButtonInfo>().Quantity.text = ItemShop[3, ButtonRef.GetComponent<ButtonInfo>().WeaponID].ToString();
            player.runSpeed += .25f;
        }
    }
}
