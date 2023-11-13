using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetScrollView : MonoBehaviour
{

    public ScrollRect ScrollView;

    private void OnEnable() 
    {
        ScrollView.verticalNormalizedPosition = 1;
    }


}
