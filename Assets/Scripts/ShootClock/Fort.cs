using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
    public List<GameObject> BulletList=new List<GameObject>();  //�[��̼Ҧ�-�D��ݼs����
    public float FortSpeed;
    public ObjectsPool _FortBulletPool;
    public enum Ctrl { ���ާ@,�k�ާ@}
    public Ctrl _Ctrl;
    bool IsChangeButtleType;
    private void Update()
    {
        Rote();
    }

    
    //���x����
    public void Rote()
    {

        switch (_Ctrl)
        {
            case Ctrl.���ާ@:
                if (Input.GetKey(KeyCode.D))
                {
                    gameObject.transform.Rotate(Vector3.forward, -1 * FortSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    gameObject.transform.Rotate(Vector3.forward, FortSpeed * Time.deltaTime);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _FortBulletPool.GetComponent<ObjectsPool>().GetObjPool_O(gameObject.transform.position,gameObject.transform.rotation,null);
                }
                break;
            case Ctrl.�k�ާ@:
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    gameObject.transform.Rotate(Vector3.forward, -1 * FortSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    gameObject.transform.Rotate(Vector3.forward, FortSpeed * Time.deltaTime);
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    _FortBulletPool.GetComponent<ObjectsPool>().GetObjPool_O(gameObject.transform.position, gameObject.transform.rotation, null);
                }
                break;
            default:
                break;
        }
    }

    //�W�[���x��t
    public void AddFortSpeed()
    {
        FortSpeed += 5;
    }

    //�[��̼Ҧ�(���U�B�����B�s��)
    public void AddBulletList(GameObject bts)
    {
        BulletList.Add(bts);
    }

    public void RemoveBulletList(GameObject bts)
    {
        BulletList.Remove(bts);
    }

    public void ChangeBulletsType()
    {
         IsChangeButtleType= !IsChangeButtleType; ;
        if (IsChangeButtleType)
        {
            foreach (var bts in BulletList)
            {
                bts.GetComponent<Bullets>()._Calculation = Bullets.Calculation.�[;
                Debug.Log("�l�u��+�k");
            }
        }
        else
        {
            foreach (var bts in BulletList)
            {
                bts.GetComponent<Bullets>()._Calculation = Bullets.Calculation.��;
                Debug.Log("�l�u��-�k");
            }
        }
     
    }

    

}
