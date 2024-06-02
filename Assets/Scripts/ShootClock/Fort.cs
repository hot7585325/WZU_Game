using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public List<GameObject> BulletList=new List<GameObject>();  //觀察者模式-主體兼廣播者
    public float FortSpeed;
    public ObjectsPool _FortBulletPool;
    public enum Ctrl { 左操作,右操作}
    public Ctrl _Ctrl;
    bool IsChangeButtleType;
    private void Update()
    {
        KeyBoardCtrl();
        UICtrl();
    }

    
    //鍵盤砲台操作
    public void KeyBoardCtrl()
    {

        switch (_Ctrl)
        {
            case Ctrl.左操作:
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
                    SoundManager.Instance.Create_AS();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    ChangeBulletsType();
                }
                break;
            case Ctrl.右操作:
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
                    SoundManager.Instance.Create_AS();
                }

                if (Input.GetKeyDown(KeyCode.O))
                {
                    ChangeBulletsType();
                }
                break;
            default:
                break;
        }
    }

    //增加砲台轉速
    public void AddFortSpeed()
    {
        FortSpeed += 50;
    }

    //觀察者模式(註冊、移除、廣播)
    public void AddBulletList(GameObject bts)
    {
        BulletList.Add(bts);
    }

    public void RemoveBulletList(GameObject bts)
    {
        BulletList.Remove(bts);
    }

    //改變子彈類型(+-彈)
    public void ChangeBulletsType()
    {
         IsChangeButtleType= !IsChangeButtleType; ;
        if (IsChangeButtleType)
        {
            foreach (var bts in BulletList)
            {
                bts.GetComponent<Bullets>().SetBulletType(1);
                Debug.Log("子彈為+法");
            }
        }
        else
        {
            foreach (var bts in BulletList)
            {
                bts.GetComponent<Bullets>().SetBulletType(-1);
                Debug.Log("子彈為-法");
            }
        }
     
    }

    //子彈尺寸
    public void ChangeBulletsSize()
    {

        foreach (var bts in BulletList)
        {
            bts.GetComponent<Bullets>().BigButtleSize();
            Debug.Log("子彈變大");
        }
    }


    public void UICtrl()
    {
        if (variableJoystick != null)
        {
            Vector3 direction = Vector3.forward * variableJoystick.Horizontal+Vector3.forward * variableJoystick.Vertical;
            gameObject.transform.Rotate(direction, -1 * FortSpeed * Time.deltaTime);
        }
    }

    public void UIFire()
    {
        _FortBulletPool.GetComponent<ObjectsPool>().GetObjPool_O(gameObject.transform.position, gameObject.transform.rotation, null);
    }


}
