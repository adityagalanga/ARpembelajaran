using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            CheckTarget(Input.GetTouch(0).position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CheckTarget(Input.mousePosition);
        }
    }

    private void CheckTarget(Vector3 Position)
    {
        Ray ray = Camera.main.ScreenPointToRay(Position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "TargetTouchText")
            {
                hit.transform.GetComponent<TargetTextController>().ShowText();
            }
        }
    }
}
