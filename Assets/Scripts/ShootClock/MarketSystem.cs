using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSystem : Singleton<MarketSystem>
{
    [Header("�󴫥ֽ�������")]
    public GameObject ClockBody;
    public List<Item> SkinItem = new List<Item>();


    //�R�ֽ�

     void BuySkin(int SkinId)
    {
        int price = SkinItem[SkinId].Price;
        Coin.Instance.Pay(price);
        if (Coin.Instance.PayFinish)
        {
            ClockBody.GetComponent<SpriteRenderer>().sprite = SkinItem[SkinId]._Sprite;
            SkinItem[SkinId].isPurchased=true;
            Debug.Log("��");
        }
        else
        {
            Debug.Log("�S����");
        }
    }

    //�ˬd�O�_�w�g�ʶR�ֽ��A�Y�O�����󴫡A�h������O�����ʶR

    public void ChangeSkin(int SkinId)
    {
        if (SkinItem[SkinId].isPurchased == true)
        {
            ClockBody.GetComponent<SpriteRenderer>().sprite = SkinItem[SkinId]._Sprite;
        }
        else
        {
            BuySkin(SkinId);
        }
    }

}
