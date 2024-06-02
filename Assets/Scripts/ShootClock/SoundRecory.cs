using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRecory : MonoBehaviour
{
    public ObjectsPool AS_OP;


    

    private void Update()
    {
        RecoveryAS();
    }

    public void RecoveryAS()
    {
        AudioSource _AS = GetComponent<AudioSource>();
        if (_AS.isPlaying == false)
        {
            AS_OP.SetObjPool_O(gameObject);
        }
    }

}
