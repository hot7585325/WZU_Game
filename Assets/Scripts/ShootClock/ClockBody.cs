using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockBody : MonoBehaviour
{
    public float HP;
    public Slider _Slider_HP;
    public GameObject LoseImage;

    private void Start()
    {
        LoseImage.SetActive(false);
    }
    void Update()
    {
        DisplayUI();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "Num")
        {
            HpCount(collision);
        }
    }

    public void HpCount(Collider2D collision)
    {
        float Damage= collision.GetComponent<Num>().GetNumDamage();
        if (HP>= Damage)
        {
            HP -= Damage;
            Debug.Log("¶Ë®`" + Damage + "¥Í©R­È¾l" + HP);
        }
        else
        {
            LoseImage.SetActive(true);
        }
    }

    public void HpAdd()
    {
        HP += 10;
        if (HP >= 100)
        {
            HP = 100;
        }
    }

    public void DisplayUI()
    {
        _Slider_HP.value = HP;
    }
}
