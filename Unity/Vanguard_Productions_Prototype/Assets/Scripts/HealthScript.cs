using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private animationScript animationScript;
    private EnemyMovement enemyMovement;

    private bool characterDied;

    public bool is_Player;

    private float heavyDMG = 5f;

    void Awake()
    {
        animationScript = GetComponentInChildren<animationScript>();
    }

    public void ApplyDamage(float damage, bool heavy)
    {
        if(characterDied)
        {
            return;
        }

        //Calculate Damage
        // if heavy attack
        if(heavy)
        {
            health -= damage * heavyDMG;
        }
        else
        {
            // decrement health
            health -= damage;
        }

        


        // if character died
        if(health <= 0f)
        {
            animationScript.Death();
            characterDied = true;
            GetComponent<EnemyMovement>().enabled = false;
        }

        if(is_Player)
        {
            return;
        }

        if(!is_Player)
        {
            animationScript.Hit();

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

}
