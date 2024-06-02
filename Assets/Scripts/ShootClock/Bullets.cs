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

    //檢視是+彈還是-彈
    public int GetBulletType()
    {
        return type;
    }

    //設定子彈類型
    public void SetBulletType(int calculation)
    {
        type = calculation;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Num"&& collision.GetComponent<Num>().IsChangeNum)
        {
            Debug.Log("碰到數字，子彈回收");
            _FortBulletPool.GetComponent<ObjectsPool>().SetObjPool_O(gameObject);
        }
    }

    //回收
    public void Recovery()
    {
         time+= Time.deltaTime;
        if (time >= 1)
        {
            time = 0;
            Debug.Log("時間到，子彈回收");
            _FortBulletPool.GetComponent<ObjectsPool>().SetObjPool_O(gameObject);
        }
    }

    public void BigButtleSize()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
    }


}
