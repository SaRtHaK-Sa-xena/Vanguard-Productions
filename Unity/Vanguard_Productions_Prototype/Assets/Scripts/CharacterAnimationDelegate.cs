using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject begToMid_Sword_Attack_Point, rangedAttack;

    // Enemy
    public GameObject attackPoint;

    // Boss Enemy
    // Warden attack points
    public GameObject WardenLeftHand;
    public GameObject WardenRightHand;

    private CameraShake shakeCamera;
    public animationScript animationScript;

    // Camera Shake
    private void Awake()
    {
        animationScript = GetComponent<animationScript>();
        //shakeCamera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    // Ranged Particle
    void ranged_Attack_On()
    {
        rangedAttack.SetActive(true);
    }

    void ranged_Attack_Off()
    {
        if(rangedAttack.activeInHierarchy)
        {
            rangedAttack.SetActive(false);
        }
    }

    void begToMid_Sword_Attack_On()
    {
        begToMid_Sword_Attack_Point.SetActive(true);
    }

    void begToMid_Sword_Attack_Off()
    {
        if(begToMid_Sword_Attack_Point.activeInHierarchy)
        {
            begToMid_Sword_Attack_Point.SetActive(false);
        }
    }

    void attackPoint_on()
    {
        attackPoint.SetActive(true);
    }

    void attackPoint_off()
    {
        if(attackPoint.activeInHierarchy)
        {
            Debug.Log("attack off");
            attackPoint.SetActive(false);
        }
    }

    void wardenLeftHand_on()
    {
        WardenLeftHand.SetActive(true);
    }

    void wardenLeftHand_off()
    {
        if (WardenLeftHand.activeInHierarchy)
        {
            WardenLeftHand.SetActive(false);
        }
    }

    void wardenRightHand_on()
    {
        WardenRightHand.SetActive(true);
    }

    void wardenRightHand_off()
    {
        if (WardenRightHand.activeInHierarchy)
        {
            WardenRightHand.SetActive(false);
        }
    }

    // Warden Anims
    // End Credits
    public void EndCredits()
    {
        // end credit scene
        SceneManager.LoadScene(2);
    }


    void Tag_BegToMid_Sword_Point()
    {
        begToMid_Sword_Attack_Point.tag = "begToMid_Point";
    }

    void UnTag_BegToMid_Sword_Point()
    {
        begToMid_Sword_Attack_Point.tag = "Untagged";
    }

    // Ranged Tag
    void Tag_Ranged_Attack_Particle()
    {
        rangedAttack.tag = "ranged_attackPoint";
    }

    void UnTag_Ranged_Attack_Particle()
    {
        rangedAttack.tag = "Untagged";
    }
}
