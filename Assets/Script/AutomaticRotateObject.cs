using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRotateObject : MonoBehaviour
{
    public float speed;
    public int x;
    public int y;
    public int z;
    void Update()
    {
        transform.Rotate(x * speed, y * speed, z * speed);
    }
}
