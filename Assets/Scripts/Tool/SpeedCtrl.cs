using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCtrl : MonoBehaviour
{
    public float TimeSpeed;

    void Update()
    {
        Time.timeScale = TimeSpeed;
    }
}
