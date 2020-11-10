using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float UI_health;

    public float MaxHealth = 130f;

    private animationScript animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    private float heavyDMG = 5f;

    private int noPlayerLayer = 13;

    // Health event UI
    public event UnityAction<float> OnHealthPctChanged = delegate { }; // pass in null to avoid null check


    void Awake()
    {
        animationScript = GetComponentInChildren<animationScript>();
        
        if(is_Player)
        {
            health = MaxHealth;
            UI_health = health;
        }
    }

    public void ApplyDamage(float damage, bool heavy)
    {
        

        if (characterDied)
        {
            return;
        }

        //Calculate Damage
        // if heavy attack
        if(heavy)
        {
            health -= damage * heavyDMG;
            GetComponent<Rigidbody>().AddForce(-transform.forward * 2f);
        }
        else
        {
            // decrement health
            health -= damage;
            if(is_Player)
            {   
                ModifyHealthValue(-damage);
            }
        }




        // if character died
        if (health <= 0f)
        {
            if (!is_Player)
            {
                // player will not be able to touch enemy
                gameObject.layer = noPlayerLayer;
                animationScript.Death();
                characterDied = true;
                if(GetComponent<EnemyMovement>())
                {
                    GetComponent<EnemyMovement>().enabled = false;
                    GetComponent<EnemyMovement>().timeTracker = 0;
                    GetComponent<EnemyMovement>().TurnOffStun();
                }
                if(GetComponent<CrabAI>())
                {
                    GetComponent<CrabAI>().enabled = false;
                    GetComponent<CrabAI>().timeTracker = 0;
                    GetComponent<CrabAI>().TurnOffStun();
                }
                
            }
            else
            {
                // Start teleport
                FindObjectOfType<CheckPoint>().teleportPlayer();
            }
            
        }

        if(is_Player)
        {
            return;
        }

        if(!is_Player)
        {
            animationScript.Hit();

            if(GetComponent<EnemyMovement>())
            {
                GetComponent<EnemyMovement>().staggered = true;
            }
            if(GetComponent<CrabAI>())
            {
                GetComponent<CrabAI>().staggered = true;
            }
            //Debug.Log("Checking Hit Animate");
            //if(Random.Range(0,3) > 1)
            //{
            //animationScript.Hit();
            //Debug.Log("Hit Animate");
            //}

            //if(knockDown)
            //{
            //if(Random.Range(0,2) > 0)
            //{
            //animationScript.knockDown();
            //}
            //}
            //else
            //{
            // if hit 
            //}
        }
    }

    void ModifyHealthValue(float amount)
    {
        UI_health += amount;

        float currentHealthPct = UI_health / MaxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

}
