using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // ====== Controls ========
        //if(Input.GetKeyDown(KeyCode.R))
        if(doRangeAnim || Input.GetKeyDown(KeyCode.R)) 
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

    void RangedAttack()
    {
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
