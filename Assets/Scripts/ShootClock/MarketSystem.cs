using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSystem : Singleton<MarketSystem>
{
    [Header("更換皮膚之物件")]
    public GameObject ClockBody;
    public List<Item> SkinItem = new List<Item>();


    //買皮膚

     void BuySkin(int SkinId)
    {
        int price = SkinItem[SkinId].Price;
        Coin.Instance.Pay(price);
        if (Coin.Instance.PayFinish)
        {
            ClockBody.GetComponent<SpriteRenderer>().sprite = SkinItem[SkinId]._Sprite;
            SkinItem[SkinId].isPurchased=true;
            Debug.Log("更換");
        }
        else
        {
            Debug.Log("沒有更換");
        }
    }

    //檢查是否已經購買皮膚，若是直接更換，則必須花費錢幣購買

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
