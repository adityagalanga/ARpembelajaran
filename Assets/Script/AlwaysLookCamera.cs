using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookCamera : MonoBehaviour
{
    void Update()
    {
        Quaternion lookRotation = Camera.main.transform.rotation;
        transform.rotation = lookRotation;
    }
}
