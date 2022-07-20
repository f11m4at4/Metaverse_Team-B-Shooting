using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOJoystick
{
    static bool bDown = false;
    static Vector3 lastMousePos;
    public static float GetAxis(string axis)
    {
        if (axis == "Horizontal")
        {
            return GetDirection().x;
        }
        else if (axis == "Vertical")
        {
            return GetDirection().y;
        }
        else
        {
            return 0;
        }
    }

    public static Vector3 GetDirection()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetButtonDown("Fire1"))
        {
            bDown = true;
            lastMousePos = Input.mousePosition;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            bDown = false;
        }
        if (bDown)
        {
            dir = Input.mousePosition - lastMousePos;
        }

        return dir.normalized;
    }
}
