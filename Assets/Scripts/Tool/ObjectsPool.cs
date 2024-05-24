using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    public Queue<GameObject> ObjPool = new Queue<GameObject>();
    public int InitialObjsCount;
    public GameObject Obj;
    public Fort _BulletFort;


    private void Awake()
    {
        InitialObjsPool();
    }
    //��l��

    public void InitialObjsPool()
    {
        for (int i = 0; i < InitialObjsCount; i++)
        {
          GameObject obj=  Instantiate(Obj);
          
          ObjPool.Enqueue(obj);
          obj.SetActive(false);
            if (_BulletFort != null)
            {
                _BulletFort.AddBulletList(obj);
            }
        }
    }


    //���X

    public void GetObjPool_O(Vector3 Pos, Quaternion Rote, Transform Parent)
    {
        if (ObjPool.Count > 0)
        {
             GameObject o = ObjPool.Dequeue();
            o.transform.parent = Parent;
            o.transform.position = Pos;
            o.transform.rotation = Rote;
            if (_BulletFort != null)
            {
                _BulletFort.AddBulletList(o);
            }
            o.SetActive(true);

        }
        else
        {
            GameObject obj = Instantiate(Obj);
            if (_BulletFort != null)
            {
                _BulletFort.AddBulletList(obj);
            }
            ObjPool.Enqueue(obj);
        }
    }




    //�^��

    public void SetObjPool_O(GameObject o)
    {
        ObjPool.Enqueue(o);
        o.SetActive(false);
    }

}
