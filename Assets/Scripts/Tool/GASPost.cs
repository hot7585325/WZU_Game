using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GASPost : MonoBehaviour
{
    public string PostWeb = "https://script.google.com/macros/s/AKfycbwWrc4QhJKXtUSWWUdeVoqJhKQZrmOl5U1MHlOt8JOa2WUQ95mnjgz1wJsgNgBk_Aim/exec";

    public string[] Answers;

    void Start()
    {
        
    }



    public void SetAnswer_1(string YN)
    {
        Answers[0] = YN;
    }
    public void SetAnswer_2(string YN)
    {
        Answers[1] = YN;
    }
    public void SetAnswer_3(string YN)
    {
        Answers[2] = YN;
    }
    public void SetAnswer_4(string YN)
    {
        Answers[3] = YN;
    }
    public void SetAnswer_5(string YN)
    {
        Answers[4] = YN;
    }
    public void Send_Answer()
    {
        StartCoroutine(Upload());
    }

    public void CleanAnswer()
    {
        for (int i = 0; i < Answers.Length; i++)
        {
            Answers[i] = "";
        }
    }


    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("answer_1", Answers[0]);
        form.AddField("answer_2", Answers[1]);
        form.AddField("answer_3", Answers[2]);
        form.AddField("answer_4", Answers[3]);
        form.AddField("answer_5", Answers[4]);

        UnityWebRequest www = UnityWebRequest.Post(PostWeb, form);
        yield return www.SendWebRequest();
        CleanAnswer();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}
