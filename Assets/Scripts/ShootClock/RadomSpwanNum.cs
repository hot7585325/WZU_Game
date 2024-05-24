using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadomSpwanNum : MonoBehaviour
{
    public ObjectsPool _NumtPool;
    public GameObject [] SN;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RandomSpwanNum", 0, 2);

    }


    //�Ыؤl�u
    public void CreateNum(GameObject NumFort)
    {
        _NumtPool.GetObjPool_O(NumFort.transform.position, NumFort.transform.rotation, gameObject.transform);
    }


    //�H�����}�o�g��
    public void  RandomSpwanNum()
    {
        int r = Random.RandomRange(0, SN.Length);
        for (int i = 0; i < SN.Length; i++)
        {
            SN[i].gameObject.SetActive(false);
        }
        SN[r].gameObject.SetActive(true);
        CreateNum(SN[r].gameObject);
    }

}
