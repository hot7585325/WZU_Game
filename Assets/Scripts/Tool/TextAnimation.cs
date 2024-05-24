using UnityEngine;
using UnityEngine.UI;

public class TextAnimation : MonoBehaviour
{
    public Text textObject;
    public string fullText;
    public float delayBetweenCharacters = 0.2f;

    private string currentText = "";
    private int currentIndex = 0;
    private float timer = 0f;

    void Start()
    {
        textObject.text = ""; // 初始化文本内容为空
    }

    void Update()
    {
        GptWrite();
    }

    public void GptWrite()
    {
        timer += Time.deltaTime;

        if (timer >= delayBetweenCharacters && currentIndex < fullText.Length)
        {
            currentText += fullText[currentIndex]; // 逐步增加文本内容
            textObject.text = currentText;
            currentIndex++;
            timer = 0f;
        }
    }


}
