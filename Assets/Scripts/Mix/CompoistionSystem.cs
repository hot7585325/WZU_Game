using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompoistionSystem : MonoBehaviour
{
    [Header("�`��������")]
    public List<Element> Elements=new List<Element>();

    [Header("���~")]
    public GameObject[] Product;

    [Header("��ܪ�ui")]
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

    //Ĳ�I��`������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "elements")
        {
            //�[�J�M��
            if (Elements.Count < 2)
            {
                Elements.Add(collision.gameObject.GetComponent<Element>());
            }
            
            //��m���s�ϰ�
            ReadyArea(collision);
        }
    }



    //�X��
    public void Compoistion() //�q�`��������h�P�_�O�_�F���Ͳ�����
    {   if(Elements[0]!=null&&Elements[1] != null&& Elements[0].GetComponent<Element>().Type!= Elements[1].GetComponent<Element>().Type)
        {
            
            ///�[�J���ҬۦP�h�R������åͲ��s����
            if (Elements[0].GetComponent<Element>().IsClock && Elements[1].GetComponent<Element>().IsClock)
            {
                ElementImages[2].sprite = Product[0].GetComponent<SpriteRenderer>().sprite;
                ElementImages[2].gameObject.SetActive(true);
                Debug.Log("������ ");
                CrateProduct(0);
            }

            if (Elements[0].GetComponent<Element>().IsColth && Elements[1].GetComponent<Element>().IsColth)
            {
                ElementImages[2].sprite = Product[1].GetComponent<SpriteRenderer>().sprite;
                ElementImages[2].gameObject.SetActive(true);
                Debug.Log("����A ");
                CrateProduct(1);
            }

            if (Elements[0].GetComponent<Element>().IsUmbrella && Elements[1].GetComponent<Element>().IsUmbrella)
            {
                ElementImages[2].sprite = Product[2].GetComponent<SpriteRenderer>().sprite;
                ElementImages[2].gameObject.SetActive(true);
                Debug.Log("���� ");
                CrateProduct(2);
            }
        }
        else
        {
            ElementImages[2].gameObject.SetActive(false);
        }
    }

    //�Ы�
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


    //����
    public void RemoveAll()
    {
        Elements.Clear();
        ElementImages[0].gameObject.SetActive(false);
        ElementImages[1].gameObject.SetActive(false);
        ElementImages[2].gameObject.SetActive(false);
    }

    //���s��
    public void ReadyArea(Collision2D collision)
    {
        collision.collider.gameObject.SetActive(false);
    }

    //ui���
    public void UIDisplay()//�S�����A�S��k����
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
