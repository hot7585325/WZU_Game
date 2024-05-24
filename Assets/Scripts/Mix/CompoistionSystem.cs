using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompoistionSystem : MonoBehaviour
{
    [Header("蒐集的元件")]
    public List<Element> Elements=new List<Element>();

    [Header("成品")]
    public GameObject[] Product;

    [Header("顯示的ui")]
    public List<Image> ElementImages=new List<Image>();


    public bool IsCreat;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveAll();
        }
       
        UIDisplay();
        Compoistion();
    }

    //觸碰後蒐集物件
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "elements")
        {
            //加入清單
            if (Elements.Count < 2)
            {
                Elements.Add(collision.gameObject.GetComponent<Element>());
            }
            
            //放置站存區域
            ReadyArea(collision);
        }
    }



    //合成
    public void Compoistion() //從蒐集的物件去判斷是否達成生產條件
    {   if(Elements[0]!=null&&Elements[1] != null&& Elements[0].GetComponent<Element>().Type!= Elements[1].GetComponent<Element>().Type)
        {
            
            ///加入標籤相同則刪除物件並生產新物件
            if (Elements[0].GetComponent<Element>().IsClock && Elements[1].GetComponent<Element>().IsClock)
            {
                ElementImages[2].sprite = Product[0].GetComponent<SpriteRenderer>().sprite;
                ElementImages[2].gameObject.SetActive(true);
                Debug.Log("產時鐘 ");
                CrateProduct(0);
            }

            if (Elements[0].GetComponent<Element>().IsColth && Elements[1].GetComponent<Element>().IsColth)
            {
                ElementImages[2].sprite = Product[1].GetComponent<SpriteRenderer>().sprite;
                ElementImages[2].gameObject.SetActive(true);
                Debug.Log("產衣服 ");
                CrateProduct(1);
            }

            if (Elements[0].GetComponent<Element>().IsUmbrella && Elements[1].GetComponent<Element>().IsUmbrella)
            {
                ElementImages[2].sprite = Product[2].GetComponent<SpriteRenderer>().sprite;
                ElementImages[2].gameObject.SetActive(true);
                Debug.Log("產傘 ");
                CrateProduct(2);
            }
        }
        else
        {
            ElementImages[2].gameObject.SetActive(false);
        }
    }

    //創建
    public void CrateProduct(int index)
    {
        if (Input.GetKeyDown(KeyCode.F)|| IsCreat==true)
        {
            GameObject product = Instantiate(Product[index],gameObject.transform.position+new Vector3(-1,0,0),Quaternion.identity);
            RemoveAll();
        }
    }

    public void  CrateButtonDown()
    {
        IsCreat = true;
    }
    public void CrateButtonUp()
    {
        IsCreat = false;
    }


    //移除
    public void RemoveAll()
    {
        Elements.Clear();
        ElementImages[0].gameObject.SetActive(false);
        ElementImages[1].gameObject.SetActive(false);
        ElementImages[2].gameObject.SetActive(false);
    }

    //站存區
    public void ReadyArea(Collision2D collision)
    {
        collision.collider.gameObject.SetActive(false);
    }

    //ui顯示
    public void UIDisplay()//沒有欄位，沒辦法成立
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i] != null && i < ElementImages.Count)
            {
                ElementImages[i].gameObject.SetActive(true);
                ElementImages[i].sprite = Elements[i].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }


}
