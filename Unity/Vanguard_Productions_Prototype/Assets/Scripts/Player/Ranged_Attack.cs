using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Ranged Attack
/// </summary>
public class Ranged_Attack : MonoBehaviour
{
    // spawn point of effect
    public Transform spawnPoint;

    // Effect being used
    public GameObject Effect;

    // animator
    public animationScript anim;

    PlayerControls attackController;

    private bool doRangeAnim;
    
    // checks if ranged attack fired
    public bool firedRangedAttack;

    // cooldown timer
    public float cooldown = 10.0f;

    // cooldown max
    public float cooldown_max = 0.0f;

    // text to change
    public TextMeshProUGUI cooldownText;

    private void OnEnable()
    {
        attackController.Gameplay.Enable();
    }

    private void OnDisable()
    {
        attackController.Gameplay.Disable();
    }

    private void Awake()
    {
        firedRangedAttack = false;
        cooldown = 100.0f;
        cooldown_max = 0.0f;
        attackController = new PlayerControls();
        anim = GetComponentInChildren<animationScript>();
    }

    private void Start()
    {
        attackController.Gameplay.RangedAttack.performed += _ => setRangedActive();
    }

    void setRangedActive()
    {
        doRangeAnim = true;
    }

    // Update is called once per frame
    void Update()
    {
        // adds cooldown to ranged attack
        if(firedRangedAttack)
        {
            // start cooldown
            cooldown--;
            if (cooldown <= cooldown_max)
            {
                // set fired ranged attack to false
                firedRangedAttack = false;
                cooldown = 100f;
            }
        }

        // if the attack has been fired 
        // display text of cooldown
        if(firedRangedAttack)
        {
            cooldownText.text = cooldown.ToString();
        }
        else
        {
            cooldownText.text = "Ready";
        }

        // If player control active
        if (GetComponent<PlayerControl>().allowMovement)
        {
            // if not fired ranged attack
            if (!firedRangedAttack && !FindObjectOfType<PauseMenu>().GamePaused)
            {
                // if key pressed
                if (doRangeAnim || Input.GetKeyDown(KeyCode.Z))
                {
                    RangedAttack();
                    doRangeAnim = false;
                }

                //Rotation
                if (Input.GetKeyDown(KeyCode.A))
                {
                    spawnPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                    Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(0, 0, 0);

                    //characterOrientation.y += 0.1f;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    spawnPoint.transform.eulerAngles = new Vector3(0, 0, 0);
                    Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(1, 0, 0);
                    //transform.GetChild(0).transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
    }

    void RangedAttack()
    {
        firedRangedAttack = true;

        // play animation
        anim.RangedAttack();
    }

    public void Spawn_Stun_Attack()
    {
        // Spawn particles
        Instantiate(Effect, spawnPoint);

        // Remove Parent
        spawnPoint.DetachChildren();// = null;
    }
}
