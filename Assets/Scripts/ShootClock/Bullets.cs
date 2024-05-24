using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public ObjectsPool _FortBulletPool;
    public float Speed;
    public enum Calculation { �[, �� }
    public Calculation _Calculation;
    int type;
    float time;

    private void Start()
    {
        switch (_Calculation)
        {
            case Calculation.�[:
                type = 1;
                break;
            case Calculation.��:
                type = -1;
                break;
            default:
                break;
        }
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




}
