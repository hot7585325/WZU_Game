using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpChose : MonoBehaviour
{
    public GameObject[] Chose;
    // Start is called before the first frame update



    private void OnEnable()
    {
        for (int i = 0; i < Chose.Length; i++)
        {
            Chose[i].SetActive(true);
        }
        int r = Random.RandomRange(0, Chose.Length);
        Chose[r].SetActive(false);
    }
}
