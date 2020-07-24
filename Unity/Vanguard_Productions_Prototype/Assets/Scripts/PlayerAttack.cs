using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public animationScript playerAnim;

    public bool attack;

    private void Awake()
    {
        playerAnim = GetComponentInChildren<animationScript>();
        attack = true;
    }

    private void Update()
    {
        ComboAttacks();
    }

    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(attack)
            {
                playerAnim.heavyAttack();
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerAnim.lightAttack();
        }
    }
}
