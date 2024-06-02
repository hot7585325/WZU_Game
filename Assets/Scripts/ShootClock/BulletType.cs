using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletType : MonoBehaviour
{
    public Image _Image;
    public bool IsChangeTexture;
    public Sprite A, B;
    // Start is called before the first frame update
 
    public void BulletChange()
    {
        IsChangeTexture = !IsChangeTexture;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            BulletChange();
        }

        if (IsChangeTexture)
        {
            _Image.sprite = A;
        }
        else
        {
            _Image.sprite = B;
        }
        
    }
}
