using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    public Camera _Camera;



    public void FOV_LevelUp()
    {
        _Camera.fieldOfView += 10;
    }
}
