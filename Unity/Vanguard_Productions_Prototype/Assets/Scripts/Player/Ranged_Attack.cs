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

    public ControlManager CM;

    // animator
    public animationScript anim;

    PlayerControls attackController;

    private bool doRangeAnim;
    
    // checks if ranged attack fired
    public bool firedRangedAttack;

    // cooldown timer
    public float cooldown = 0;

    // text to change
    public TextMeshProUGUI cooldownText;

    public float scalar = 0.007f;

    public GameObject coolDownBar;

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
        //cooldown = 0f;
        //cooldown_max = 0.0f;
        attackController = new PlayerControls();
        anim = GetComponentInChildren<animationScript>();
        coolDownBar.GetComponent<Image>().fillAmount = 1f;
        cooldownText.text = "Stun Attack Ready";
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
        // start cooldown
        //if (coolDownBar.GetComponent<Image>().fillAmount < 1f)
        //{
        //    Debug.Log("CoolDown");

        //    cooldown += 0.001f;

        //    // set fired ranged attack to false
        //    //firedRangedAttack = false;
        //    coolDownBar.GetComponent<Image>().fillAmount = cooldown;
        //}
        if(firedRangedAttack)
        {
            if (cooldown > 1f)
            {
                firedRangedAttack = false;
                cooldown = 0f;
            }
            else
            {
                cooldown += scalar;
                coolDownBar.GetComponent<Image>().fillAmount = cooldown;
            }
        }
        

        // if the attack has been fired 
        // display text of cooldown
        if(firedRangedAttack)
        {
            cooldownText.text = "Charging...";
        }
        else
        {
            cooldownText.text = "Stun Attack Ready";
        }

        // If player control active
        if (GetComponent<PlayerControl>().allowMovement)
        {
            // if not fired ranged attack
            if (!firedRangedAttack && !FindObjectOfType<PauseMenu>().GamePaused)
            {
                // if key pressed
                if (doRangeAnim || Input.GetKeyDown(CM.rangedAttack))
                {
                    RangedAttack();
                    doRangeAnim = false;
                }

                //Rotation
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    spawnPoint.transform.eulerAngles = new Vector3(0, 180, 0);
                    Effect.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().flip = new Vector3(0, 0, 0);

                    //characterOrientation.y += 0.1f;
                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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
        
        coolDownBar.GetComponent<Image>().fillAmount = 0;
        cooldown = 0f;
        
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
