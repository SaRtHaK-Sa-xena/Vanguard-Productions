using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    /// <summary>
    /// Delete Stun Particle Completely not inactive.
    /// </summary>


    // Stun FX
    public GameObject FX_Stun;

    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }

    private void OnParticleCollision(GameObject other)
    {
        // If Enemy
        if (other.CompareTag("Enemy"))
        {
            // Remove Blade Effect
            DeactivateAfterTime();

            // Check if enemy Stunned
            if(other.GetComponent<EnemyMovement>().stunned == true)
            {
                // set timer back to default max
                other.GetComponent<EnemyMovement>().timeTracker = 0f;
            }
            else
            {
                // Make Enemy Stunned
                other.GetComponent<EnemyMovement>().stunned = true;
                other.GetComponent<EnemyMovement>().enemyAnim.Stun_Enemy();

                //other.GetComponent<EnemyMovement>().stun
            }

            // Check if stunned particle already on player
            if(other.transform.GetChild(1).transform.childCount == 0)
            {
                // Spawn Stun Particle On Enemy
                Instantiate(FX_Stun, other.transform.GetChild(1));

                //Turn on Animation
                //other.transform.GetChild(1).transform.GetChild(0).GetComponent<animationScript>().Play_StunAnimation();
            }

            // Debug
            Debug.Log("Enemy Struck");
        }
    }
}
