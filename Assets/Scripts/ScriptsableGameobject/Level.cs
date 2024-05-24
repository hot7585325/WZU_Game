using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="LL",menuName ="OO")]
public class Level : ScriptableObject
{
    public Sprite _image;
    [TextArea]
    public string _text;
}
