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

    public GameObject Player;

    public void ChangeKeyCode(string layout)
    {
        if(layout == "Set 1")
        {
            lightAttack = KeyCode.C;
            rangedAttack = KeyCode.Z;
            grapple = KeyCode.X;
            jump = KeyCode.Space;
            Player.GetComponent<PlayerControl>().wasd = false;
        }
        if(layout == "Set 2")
        {
            lightAttack = KeyCode.J;
            rangedAttack = KeyCode.K;
            grapple = KeyCode.S;
            jump = KeyCode.Space;
            Player.GetComponent<PlayerControl>().wasd = true;
        }
    }

    private void Awake()
    {
        // default
        ChangeKeyCode("Set 1");
    }
}
