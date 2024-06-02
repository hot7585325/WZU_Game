using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : Singleton<Coin>
{

    public int Coins;
    public Text Coin_Text;
    public bool PayFinish;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        Coin_Text.text = "" + Coins;
    }
   
    private void Update()
    {
        Coin_Text.text = "" + Coins;
    }

    //�W�[����
    public void AddCoin(int Coin)
    {
        Coins += Coin;
    }

    //��I
    public void  Pay(int Pay)
    {
        if (Coins >= Pay)
        {
            Coins -= Pay;
            PayFinish = true;
        }
        else
        {
            Debug.Log("No Money");
            PayFinish = false;
        }
    }


    public bool GetPayState()
    {
        return PayFinish;
    }
}
