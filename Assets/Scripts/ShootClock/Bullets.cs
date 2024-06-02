using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public ObjectsPool _FortBulletPool;
    public float Speed;
    public int type;
    float time;


    private void Start()
    {
        SetBulletType(-1);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);

        Recovery();
    }

    //�˵��O+�u�٬O-�u
    public int GetBulletType()
    {
        return type;
    }

    //�]�w�l�u����
    public void SetBulletType(int calculation)
    {
        type = calculation;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Num"&& collision.GetComponent<Num>().IsChangeNum)
        {
            Debug.Log("�I��Ʀr�A�l�u�^��");
            _FortBulletPool.GetComponent<ObjectsPool>().SetObjPool_O(gameObject);
        }
    }

    //�^��
    public void Recovery()
    {
         time+= Time.deltaTime;
        if (time >= 1)
        {
            time = 0;
            Debug.Log("�ɶ���A�l�u�^��");
            _FortBulletPool.GetComponent<ObjectsPool>().SetObjPool_O(gameObject);
        }
    }

    public void BigButtleSize()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }


}
