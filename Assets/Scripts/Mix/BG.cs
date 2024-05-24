using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public GameObject Floor;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Floor.transform.position = new Vector3(Target.transform.position.x, Floor.transform.position.y, Floor.transform.position.z);


    }
}
