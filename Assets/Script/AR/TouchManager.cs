using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private const float HoldTime = 0.1f;
    private float currentTime = 0;

    private int TextLayer = 6;
    private int RotateLayer = 7;

    private Vector3 LastPosition;
    private bool _triggeredHold = false;
    private bool OnCheck = false;

    private TargetRotate CurrentTargetRotate;

    void Update()
    {


#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            OnCheck = true;
            _triggeredHold = false;
            currentTime = 0;
            LastPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            LastPosition = Input.mousePosition;
            currentTime += Time.deltaTime;

            if (currentTime >= HoldTime && !_triggeredHold)
            {
                _triggeredHold = true;
                OnHoldInit();
            }
        }
        else
        {
            if (OnCheck)
            {
                if (_triggeredHold == false)
                {
                    OnTapInit();
                }

                if (_triggeredHold)
                {
                    OnHoldRelease();
                    _triggeredHold = false;
                }

                OnCheck = false;
            }
        }

#elif UNITY_ANDROID
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnCheck = true;
                _triggeredHold = false;
                currentTime = 0;
            }

            LastPosition = Input.GetTouch(0).position;
            currentTime += Time.deltaTime;

            if (currentTime >= HoldTime && !_triggeredHold)
            {
                _triggeredHold = true;
                OnHoldInit();
            }
        }
        else
        {
            if (OnCheck)
            {
                if (_triggeredHold == false)
                {
                    OnTapInit();
                }

                if (_triggeredHold)
                {
                    OnHoldRelease();
                    _triggeredHold = false;
                }

                OnCheck = false;
            }
        }
#endif

    }

    private void OnTapInit()
    {
        Debug.Log("On Tap");
        CheckTarget(LastPosition, true);
    }

    private void OnHoldInit()
    {
        Debug.Log("On Hold init");
        CheckTarget(LastPosition, false);
    }

    private void OnHoldRelease()
    {
        Debug.Log("On Hold release");
        if(CurrentTargetRotate != null)
        {
            CurrentTargetRotate.OnTargetRelease();
            CurrentTargetRotate = null;
        }
    }

    private void CheckTarget(Vector3 Position,bool isTap)
    {
        Ray ray = Camera.main.ScreenPointToRay(Position);
        RaycastHit hit;
        if (isTap)
        {
            int layerMask = 1 << TextLayer;
            if (Physics.Raycast(ray, out hit,Mathf.Infinity, layerMask))
            {
                if (hit.transform.tag == "TargetTouchText")
                {
                    hit.transform.GetComponent<TargetTextController>().ShowText();
                }
            }
        }
        else
        {
            int layerMask = 1 << RotateLayer;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
            {
                if (hit.transform.tag == "TargetRotate")
                {
                    CurrentTargetRotate = hit.transform.GetComponent<TargetRotate>();
                    CurrentTargetRotate.OnTargetHold();
                }
            }
        }
    }
}
