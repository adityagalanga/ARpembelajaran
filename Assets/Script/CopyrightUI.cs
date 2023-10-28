using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyrightUI : MonoBehaviour
{
    public static CopyrightUI Instance;

    private void Awake()
    {
       if(CopyrightUI.Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }
}
