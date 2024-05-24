using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teather : MonoBehaviour
{

    public bool IsMove;
    public float Speed;
    public Image WantProduct;
    [Header("�ͮ�ƭ�")]
    public float Angry;
    [Header("���~�Ϥ�")]
    public Sprite[] ProductsImage;
    [Header("��������")]
    public int FinishCount;
    [Header("������������")]
    public int  MaxFinishCount;
    [Header("���~����")]
    public int ProductType;
    [Header("���~�Ϥ�����")]
    public int ProductImageType;
    [Header("���a")]
    public GameObject Player;

    public Text FinishCountText;
    public Slider AngryValueSlider;
    public GameObject WinImage;
    public GameObject OverImage;
    //�H���Ͳ��@�շQ�n�����~�Ϥ�
    //�I����������~��type
    //��令�~�P���~�Ϥ���type
    //�ۦP�U�@�Ӳֿn��������
    //���P�W�[�ͮ��


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

    //����
    public void Movement()
    {
        if (IsMove)
        {
            gameObject.transform.Translate(1 * Time.deltaTime * Speed, 0, 0);
        }
    }

    //�t���ܴ�
    public void SpeedChange()
    {
        float Distance = Player.transform.position.x - transform.position.x;
        if (Distance > 10)
        {
            Debug.Log("�[�t");
            Speed = 8;
        }
        if(Distance < 5)
        {
            Speed = 6;
        }
       
    }

    //�����ʵe��Ұ�-��
    public void IsMoveTrue()
    {
        IsMove = true;
    }


    //�����H�����~�Ϥ�
    public void RadomCreateProductImage()
    {
        Debug.Log("�H����" + ProductImageType);
        ProductImageType = Random.RandomRange(0, ProductsImage.Length);
        WantProduct.sprite = ProductsImage[ProductImageType];
    }

    //�I����������~��type
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

    //�P�_���~�����O�_�ۦP
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


    //��_�t��
    IEnumerator ReSetSpeed(float sec)
    {
        yield return new WaitForSeconds(sec);
        IsMove = true;
    }

    //�ͮ�ȭp��
    public void AngryCount()
    {
        AngryValueSlider.value = Angry/100;
        if (Angry == 100)
        {
            OverImage.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    //���\�p��
    public void FinishCountCount()
    {
        FinishCountText.text = ""+(MaxFinishCount-FinishCount);

        if (FinishCount == MaxFinishCount)
        {
            WinImage.SetActive(true);
        }
    }

}
