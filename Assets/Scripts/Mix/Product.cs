using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public int Type;
    public float Speed=5;
    // Start is called before the first frame update
    public AudioSource _AS;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1*Time.deltaTime*Speed, 0, 0);
    }


    private void OnEnable()
    {
        _AS.Play();
    }

}
