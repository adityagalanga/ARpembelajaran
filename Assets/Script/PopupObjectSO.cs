using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class PopupObjectSO : ScriptableObject
{
    public ObjectLasID ID;
    public string PopupTitle;
    public Texture2D PopupTexture;
    [TextArea(3, 10)]
    public string PopupText;
}
