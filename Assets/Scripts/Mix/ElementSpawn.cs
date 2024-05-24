using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawn : MonoBehaviour
{
 
    [Header("�Ͳ�������")]
    public GameObject[] Elements;
    [Header("�O�_�H�����j")]
    public bool IsRandomSpacing;
    [Header("���Z")]
    public float Spacing=5;
    public float RadomSpacing = 5;
    [Header("�Z���h�֥Ͳ�")]
    public float SpawnDistance=20;
    [Header("���a��m")]
    public GameObject Player;
    [Header("�̲ת������m")]
     Vector3 EndObjPos;




    //����̫�@�Ӫ��󪺦�m�A���a��o�Ӫ��󪺶Z���p��Y¾�A�F��Ыر���
    void Start()
    {
        RadomSpacing = Spacing;
        InintialCrate();

        // CreateDistance = Player.transform.position.x + Spacing;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRandomSpacing)
        {
            Spacing = Random.RandomRange(RadomSpacing, RadomSpacing * 5);
        }
        else
        {
            Spacing = Spacing;
        }

        CreatElements();

       

    }

    //��l�Ͳ�
    private void InintialCrate()
    {
        for (int i = 0; i < 5; i++)
        {
            int r = Random.RandomRange(0, Elements.Length);
           GameObject Element= Instantiate(Elements[r], new Vector3(Spacing*i, 0, 0), Quaternion.identity);
            Element.transform.parent = gameObject.transform;
            GetEndObjPos(Element);
        }
        
    }


    //��s�̲ת��󪺦�m
    public void GetEndObjPos(GameObject ObjPos)
    {
        EndObjPos = ObjPos.transform.position;
    }

    //�}�l�Ы�
    public void CreatElements()
    {
        if(EndObjPos.x- Player.transform.position.x <= SpawnDistance) 
        {
            EndObjPos = new Vector3(EndObjPos.x + Spacing, EndObjPos.y, EndObjPos.z);
            int r = Random.RandomRange(0, Elements.Length);
                GameObject Element = Instantiate(Elements[r], EndObjPos, Quaternion.identity);
            Element.transform.parent = gameObject.transform;
            GetEndObjPos(Element);
        }
    }







}
