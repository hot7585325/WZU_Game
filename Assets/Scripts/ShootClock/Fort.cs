using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public List<GameObject> BulletList=new List<GameObject>();  //�[��̼Ҧ�-�D��ݼs����
    public float FortSpeed;
    public ObjectsPool _FortBulletPool;
    public enum Ctrl { ���ާ@,�k�ާ@}
    public Ctrl _Ctrl;
    bool IsChangeButtleType;
    private void Update()
    {
        KeyBoardCtrl();
        UICtrl();
    }

    
    //��L���x�ާ@
    public void KeyBoardCtrl()
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
                    SoundManager.Instance.Create_AS();
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    ChangeBulletsType();
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

    //�W�[���x��t
    public void AddFortSpeed()
    {
        FortSpeed += 50;
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

    //���ܤl�u����(+-�u)
    public void ChangeBulletsType()
    {
         IsChangeButtleType= !IsChangeButtleType; ;
        if (IsChangeButtleType)
        {
            foreach (var bts in BulletList)
            {
                bts.GetComponent<Bullets>().SetBulletType(1);
                Debug.Log("�l�u��+�k");
            }
        }
        else
        {
            foreach (var bts in BulletList)
            {
                bts.GetComponent<Bullets>().SetBulletType(-1);
                Debug.Log("�l�u��-�k");
            }
        }
     
    }

    //�l�u�ؤo
    public void ChangeBulletsSize()
    {

        foreach (var bts in BulletList)
        {
            bts.GetComponent<Bullets>().BigButtleSize();
            Debug.Log("�l�u�ܤj");
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
