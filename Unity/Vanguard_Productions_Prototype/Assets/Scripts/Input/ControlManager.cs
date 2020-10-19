using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    //
    public KeyCode lightAttack;
    public KeyCode rangedAttack;
    public KeyCode grapple;
    public KeyCode jump;
    public KeyCode panUp;


    void ChangeKeyCode(string layout)
    {
        if(layout == "normal")
        {
            lightAttack = KeyCode.C;
            rangedAttack = KeyCode.Z;
            grapple = KeyCode.X;
            jump = KeyCode.Space;
            panUp = KeyCode.W;
        }
        if(layout == "mouse")
        {
            lightAttack = KeyCode.Mouse0;
            rangedAttack = KeyCode.Mouse1;
            grapple = KeyCode.Mouse2;
            jump = KeyCode.Mouse3;
            panUp = KeyCode.Mouse4;
        }
    }
}
