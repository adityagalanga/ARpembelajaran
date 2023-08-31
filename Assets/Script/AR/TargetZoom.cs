using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetZoom : MonoBehaviour
{
    public GameObject Target;
    Vector3 CurrentTargetScale;

    Vector3 touchStart;
    float zoomOutMin;
    float zoomOutMax;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTargetScale = Target.transform.localScale;
        zoomOutMin = CurrentTargetScale.x;
        zoomOutMax = CurrentTargetScale.x + 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrev = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrev = touchOne.position - touchOne.deltaPosition;

            float prevMag = (touchZeroPrev - touchOnePrev).magnitude;
            float currentMag = (touchZero.position - touchOne.position).magnitude;

            float diff = currentMag - prevMag;

            zoom(diff * 0.01f);
        }

        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    private void zoom(float increment)
    {
        CurrentTargetScale.x = Mathf.Clamp(CurrentTargetScale.x += increment, zoomOutMin, zoomOutMax);
        CurrentTargetScale.y = Mathf.Clamp(CurrentTargetScale.y += increment, zoomOutMin, zoomOutMax);
        CurrentTargetScale.z = Mathf.Clamp(CurrentTargetScale.z += increment, zoomOutMin, zoomOutMax);

        Target.transform.localScale = CurrentTargetScale;
    }
}
