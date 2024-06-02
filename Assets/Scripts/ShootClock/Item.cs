using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image _Image;
    public Text _Text;

    public Sprite _Sprite;
    public int Price;
    public bool isPurchased;

    private void Start()
    {
        isPurchased = false;
        _Image=GetComponent<Image>();
    }


    private void Update()
    {
        UIDisplay();
    }

    public void UIDisplay()
    {
        _Image.sprite = _Sprite;

        if (isPurchased)
        {
            _Text.text = "§ó´«";
        }
        else
        {
            _Text.text = "" + Price;
        }
     
    }



}
