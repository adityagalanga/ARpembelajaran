using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTextController : MonoBehaviour
{
    public GameObject TextObject;

    public void Start()
    {
        TextObject.SetActive(false);
    }

    public void ShowText()
    {
        TextObject.SetActive(true);
    }
}
