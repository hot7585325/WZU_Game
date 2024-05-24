using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public ObjectsPool _FortBulletPool;
    public float Speed;
    public enum Calculation { 加, 減 }
    public Calculation _Calculation;
    int type;
    float time;

    private void Start()
    {
        switch (_Calculation)
        {
            case Calculation.加:
                type = 1;
                break;
            case Calculation.減:
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

    //檢視是+彈還是-彈
    public int GetBulletType()
    {
        return type;
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




}
