using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Num : MonoBehaviour
{
    public int Index;
    public GameObject Target;
    public float Speed;
    public Sprite[] Index_Sprite;
    public SpriteRenderer _SR;
    public bool IsChangeNum;
    public ObjectsPool _NumtPool;
    public float Damage;
 
    private void OnEnable()
    {
        int R = Random.RandomRange(0, 12);
        Index = R + 1;
        _SR.sprite = Index_Sprite[R];
        IsChangeNum = true;
    }

    void Update()
    {
        Damage = Index;
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet"&& IsChangeNum)
        {
            int value = collision.gameObject.GetComponent<Bullets>().GetBulletType();
            Index += value;
            _SR.sprite = Index_Sprite[Index-1];
            Debug.Log(gameObject.name + Index);
            if (Index <= 0)
            {
              _NumtPool.GetComponent<ObjectsPool>().SetObjPool_O(gameObject);
            }
        }
        if (collision.tag == "Player")
        {
             _NumtPool.GetComponent<ObjectsPool>().SetObjPool_O(gameObject);
        }
    }

    public void SetIsChangeNum(bool TF)
    {
        IsChangeNum = TF;
    }

    public float GetNumDamage()
    {
        return Damage;
    }


    public void Move()
    {
        float ShootSpeed = Random.RandomRange(1, Speed);

        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, ShootSpeed * Time.deltaTime);
    }


}
