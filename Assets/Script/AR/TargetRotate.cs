using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotate : MonoBehaviour
{
    [SerializeField] private GameObject TargetObject;

    [SerializeField]
    private Quaternion defaultAvatarRotation;

    [SerializeField]
    private float speedRotation = 0.03f;

    private float prevX;
    private float prevY;

    private bool isRotating = false;

    private void Update()
    {
        if (isRotating)
        {
#if UNITY_EDITOR
            var touch = Input.mousePosition;
            float deltaY = -(Input.mousePosition.x - prevX) * speedRotation;
            float deltaX = (Input.mousePosition.y - prevY) * speedRotation;

            Vector3 rot = TargetObject.transform.rotation.eulerAngles + new Vector3(deltaX, deltaY, 0f); //use local if your char is not always oriented Vector3.up
            rot.x = ClampAngle(rot.x, -80f, 80f);

            TargetObject.transform.eulerAngles = rot;

            prevX = Input.mousePosition.x;
            prevY = Input.mousePosition.y;
#elif UNITY_ANDROID
                var touch = Input.touches[0];
                var deltaY = -(touch.position.x - prevX) * speedRotation;
                var deltaX = (touch.position.y - prevY) * speedRotation;

                Vector3 rot = CharacterObj.transform.rotation.eulerAngles + new Vector3(deltaX, deltaY, 0f); //use local if your char is not always oriented Vector3.up
                rot.x = ClampAngle(rot.x, -80f, 80f);

                CharacterObj.transform.eulerAngles = rot;

                prevX = touch.position.x;
                prevY = touch.position.y;
#endif
        }
        else
        {
            Quaternion currentRotation = TargetObject.transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, currentRotation.eulerAngles.y, 0);
            TargetObject.transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * 120f);
        }
    }

    public void MouseButtonDown()
    {
#if UNITY_EDITOR
        prevX = Input.mousePosition.x;
        prevY = Input.mousePosition.y;

#elif UNITY_ANDROID
            prevX = Input.touches[0].position.x;
            prevY = Input.touches[0].position.y;
#endif
        isRotating = true;
    }

    public void MouseButtonUp()
    {
        isRotating = false;
    }

    public void ResetRotate()
    {
        isRotating = false;
        TargetObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    }



    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }

}
