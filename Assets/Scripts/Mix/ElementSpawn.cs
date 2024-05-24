using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawn : MonoBehaviour
{
 
    [Header("生產的元件")]
    public GameObject[] Elements;
    [Header("是否隨機間隔")]
    public bool IsRandomSpacing;
    [Header("間距")]
    public float Spacing=5;
    public float RadomSpacing = 5;
    [Header("距離多少生產")]
    public float SpawnDistance=20;
    [Header("玩家位置")]
    public GameObject Player;
    [Header("最終的物件位置")]
     Vector3 EndObjPos;




    //獲取最後一個物件的位置，當玩家跟這個物件的距離小於某職，達到創建條件
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

    //初始生產
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


    //更新最終物件的位置
    public void GetEndObjPos(GameObject ObjPos)
    {
        EndObjPos = ObjPos.transform.position;
    }

    //開始創建
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
