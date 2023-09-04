using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TeoriButtonListener : MonoBehaviour
{
    public TeoriButtonListener TargetMenuWhenBack;

    public bool ListenBackButton = true;

    public TeoriButtonListener TargetMenuWhenClicked;

    public UnityEvent OnActiveMenu;
    public UnityEvent OnDisableMenu; 
     
    public void OnUIActive()
    {
        OnActiveMenu!.Invoke();
    }

    public void OnUIDisable()
    {
        OnDisableMenu!.Invoke();
    }


    public void OnButtonClicked()
    {
        if(TargetMenuWhenClicked != null)
        {
            TargetMenuWhenClicked.OnUIActive();
        }

        OnDisableMenu!.Invoke();
    }

    public void OnButtonBackClicked()
    {
        if (TargetMenuWhenBack != null)
        {
            TargetMenuWhenBack.OnUIActive();
        }
        OnDisableMenu!.Invoke();
    }

    public void Update()
    {
        if (ListenBackButton)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnButtonBackClicked();
                return;
            }
        }
    }
} 
