using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public animationScript playerAnim;

    public SphereCollider col;

    public GameObject enemyCollider;
    public bool attack;

    private bool airAttack;

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
        if(GetComponent<jumpController>().IsGrounded())
        {
            airAttack = true;
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(attack)
            {
                playerAnim.heavyAttack();
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Check if player in grounded
            if(GetComponent<jumpController>().IsGrounded())
            {
                playerAnim.lightAttack();
            }

            // if in mid air
            else
            {
                // air attack allowed
                if(airAttack)
                {
                    // turn bool off
                    airAttack = false;

                    // aniimate mid air attack
                    playerAnim.Mid_Air_Attack();

                    // Add Force Upwards
                    GetComponent<Rigidbody>().velocity = Vector3.up * 3.5f;
                }
            }
        }
    }

}
