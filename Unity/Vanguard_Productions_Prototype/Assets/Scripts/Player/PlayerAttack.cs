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


    // Combos
    public enum ComboState
    {
        NONE,
        LIGHT_1,
        LIGHT_2,
        LIGHT_3,
        HEAVY_1,
        HEAVY_2
    }

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.9f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    // contains AttackUniversal script in Gameobject
    //public GameObject sword;

    PlayerControls attackControls;
    public bool attackNow;

    private void OnEnable()
    {
        attackControls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        attackControls.Gameplay.Disable();
    }

    private void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
        //attackControls.Gameplay.LightAttack.performed += pressedAttack => Input.GetMouseButton(0);
        attackControls.Gameplay.LightAttack.performed += pressedAttack => Attack();
        //attackControls.Gameplay.LightAttack.performed += pressedAttack => ComboAttacks();
        // check also with just calling ComboAttacks().
    }

    private void Awake()
    {
        attackControls = new PlayerControls();
        playerAnim = GetComponentInChildren<animationScript>();
        attack = true;
    }

    private void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void Attack()
    {
        attackNow = true;
    }

    public string value = "10";

    void ComboAttacks()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        if (attackNow || Input.GetKeyDown(KeyCode.C))
        {
            if (current_Combo_State == ComboState.LIGHT_3 ||
                current_Combo_State == ComboState.HEAVY_1 ||
                current_Combo_State == ComboState.HEAVY_2)
            {
                return;
            }

            // Combo
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.LIGHT_1)
            {
                // play light attack 1
                playerAnim.light_1();
            }

            if (current_Combo_State == ComboState.LIGHT_2)
            {
                // play light attack 1
                playerAnim.light_2();
            }

            if (current_Combo_State == ComboState.LIGHT_3)
            {
                // play light attack 1
                playerAnim.light_3();
            }

            // set attack to false again
            attackNow = false;
        }
    }

        //_____________________________________________________________________
        ////if (Input.GetKeyDown(KeyCode.Mouse0))
        //if (attackNow)
        //{
        //    if (current_Combo_State == ComboState.LIGHT_3 ||
        //        current_Combo_State == ComboState.HEAVY_1 ||
        //        current_Combo_State == ComboState.HEAVY_2)
        //    {
        //        return;
        //    }

        //    // Combo
        //    current_Combo_State++;
        //    activateTimerToReset = true;
        //    current_Combo_Timer = default_Combo_Timer;

        //    if (current_Combo_State == ComboState.LIGHT_1)
        //    {
        //        // play light attack 1
        //        playerAnim.light_1();
        //    }

        //    if (current_Combo_State == ComboState.LIGHT_2)
        //    {
        //        // play light attack 1
        //        playerAnim.light_2();
        //    }

        //    if (current_Combo_State == ComboState.LIGHT_3)
        //    {
        //        // play light attack 1
        //        playerAnim.light_3();
        //    }

        //    attackNow = false;
        //}
        //_____________________________________________________________________



        //if (GetComponent<jumpController>().IsGrounded())
        //{
        //    airAttack = true;
        //}

        //if(Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    if(attack)
        //    {
        //        if(current_Combo_State == ComboState.HEAVY_2 ||
        //           current_Combo_State == ComboState.LIGHT_3)
        //        {
        //            return;
        //        }

        //        if(current_Combo_State == ComboState.NONE ||
        //            current_Combo_State == ComboState.LIGHT_1 ||
        //            current_Combo_State == ComboState.LIGHT_2)
        //        {
        //            current_Combo_State = ComboState.HEAVY_1;
        //        }
        //        else if(current_Combo_State == ComboState.HEAVY_1)
        //        {
        //            current_Combo_State++;
        //        }

        //        activateTimerToReset = true;
        //        current_Combo_Timer = default_Combo_Timer;

        //        if(current_Combo_State == ComboState.HEAVY_1)
        //        {
        //            // Heavy attack 1
        //        }

        //        if (current_Combo_State == ComboState.HEAVY_2)
        //        {
        //            // Heavy attack 2
        //        }


        //        playerAnim.heavyAttack();
        //        sword.GetComponent<AttackUniversal>().heavy_attack = true;
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    // Check if player in grounded
        //    if (GetComponent<jumpController>().IsGrounded())
        //    {
        //        if (current_Combo_State == ComboState.LIGHT_3 ||
        //            current_Combo_State == ComboState.HEAVY_1 ||
        //            current_Combo_State == ComboState.HEAVY_2)
        //        {
        //            return;
        //        }

        //        // Combo
        //        current_Combo_State++;
        //        activateTimerToReset = true;
        //        current_Combo_Timer = default_Combo_Timer;

        //        if (current_Combo_State == ComboState.LIGHT_1)
        //        {
        //            // play light attack 1
        //            playerAnim.light_1();
        //        }

        //        if (current_Combo_State == ComboState.LIGHT_2)
        //        {
        //            // play light attack 1
        //            playerAnim.light_2();
        //        }

        //        if (current_Combo_State == ComboState.LIGHT_3)
        //        {
        //            // play light attack 1
        //            playerAnim.light_3();
        //        }

        //        //playerAnim.lightAttack();

        //        //sword.GetComponent<AttackUniversal>().heavy_attack = false;
        //    }

        //    // if in mid air
        //    else
        //    {
        //        // air attack allowed
        //        if(airAttack)
        //        {
        //            // turn bool off
        //            airAttack = false;

        //            // aniimate mid air attack
        //            playerAnim.Mid_Air_Attack();

        //            sword.GetComponent<AttackUniversal>().heavy_attack = false;

        //            // Add Force Upwards
        //            GetComponent<Rigidbody>().velocity = Vector3.up * 3.5f;
        //        }
        //    }
        //}


    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            if(current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.NONE;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
        
    }

}
