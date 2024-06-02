using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public ObjectsPool AS_OP;

    public void Create_AS()
    {
        AS_OP.GetObjPool_O(gameObject.transform.position, transform.rotation, gameObject.transform);
    }
}
