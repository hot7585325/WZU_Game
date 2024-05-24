using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumTrigger : MonoBehaviour
{
    public int T_Index;
    SpriteRenderer SR;
    public GameObject LevelUpPanel;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag == "Num")
        {
            if (T_Index == collision.gameObject.GetComponent<Num>().Index)
            {
                collision.gameObject.GetComponent<Num>().SetIsChangeNum(false);
                collision.gameObject.GetComponent<Num>().Target = gameObject;
                LevelUpPanel.SetActive(true);
            }
        }
    }

}
