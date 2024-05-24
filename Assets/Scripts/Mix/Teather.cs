using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teather : MonoBehaviour
{

    public bool IsMove;
    public float Speed;
    public Image WantProduct;
    [Header("生氣數值")]
    public float Angry;
    [Header("成品圖片")]
    public Sprite[] ProductsImage;
    [Header("完成次數")]
    public int FinishCount;
    [Header("必須完成次數")]
    public int  MaxFinishCount;
    [Header("成品類型")]
    public int ProductType;
    [Header("成品圖片類型")]
    public int ProductImageType;
    [Header("玩家")]
    public GameObject Player;

    public Text FinishCountText;
    public Slider AngryValueSlider;
    public GameObject WinImage;
    public GameObject OverImage;
    //隨機生產一組想要的成品圖片
    //碰撞後獲取成品的type
    //比對成品與成品圖片的type
    //相同下一個累積完成次數
    //不同增加生氣值


    private void Start()
    {
        IsMove = false;
        Angry = 0;
        RadomCreateProductImage();
    }
    private void Update()
    {
        FinishCountCount();
        AngryCount();
        Movement();
        SpeedChange();
    }

    //移動
    public void Movement()
    {
        if (IsMove)
        {
            gameObject.transform.Translate(1 * Time.deltaTime * Speed, 0, 0);
        }
    }

    //速度變換
    public void SpeedChange()
    {
        float Distance = Player.transform.position.x - transform.position.x;
        if (Distance > 10)
        {
            Debug.Log("加速");
            Speed = 8;
        }
        if(Distance < 5)
        {
            Speed = 6;
        }
       
    }

    //播完動畫後啟動-用
    public void IsMoveTrue()
    {
        IsMove = true;
    }


    //產生隨機成品圖片
    public void RadomCreateProductImage()
    {
        Debug.Log("隨機數" + ProductImageType);
        ProductImageType = Random.RandomRange(0, ProductsImage.Length);
        WantProduct.sprite = ProductsImage[ProductImageType];
    }

    //碰撞後獲取成品的type
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Product")
        {
            ProductType = collision.collider.GetComponent<Product>().Type;
            collision.collider.gameObject.SetActive(false);
            JudgeProduct();
        }
        if (collision.collider.tag == "elements"|| collision.collider.tag == "obstacle")
        {
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "Player")
        {
            //Time.timeScale = 0;
            OverImage.SetActive(true);
        }

    }

    //判斷成品類型是否相同
    public void JudgeProduct()
    {
        if(ProductType== ProductImageType)
        {
            IsMove = false;
            StartCoroutine(ReSetSpeed(1));
            FinishCount++;
        }
        else
        {
            IsMove = false;
            StartCoroutine(ReSetSpeed(0.5f));
            Angry += 20;
        }

        RadomCreateProductImage();
    }


    //恢復速度
    IEnumerator ReSetSpeed(float sec)
    {
        yield return new WaitForSeconds(sec);
        IsMove = true;
    }

    //生氣值計算
    public void AngryCount()
    {
        AngryValueSlider.value = Angry/100;
        if (Angry == 100)
        {
            OverImage.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    //成功計算
    public void FinishCountCount()
    {
        FinishCountText.text = ""+(MaxFinishCount-FinishCount);

        if (FinishCount == MaxFinishCount)
        {
            WinImage.SetActive(true);
        }
    }

}
