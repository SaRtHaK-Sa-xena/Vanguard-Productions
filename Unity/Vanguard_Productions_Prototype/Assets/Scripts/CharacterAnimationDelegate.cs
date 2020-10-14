using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{

    //public GameObject beg_Sword_Attack_Point, begToMid_Sword_Attack_Point, MidToEnd_Sword_Attack_Point, End_Sword_Attack_Point;

    public GameObject begToMid_Sword_Attack_Point, rangedAttack;

    // Enemy
    public GameObject Left_Arm_Attack_Point, Right_Arm_Attack_Point;

    private CameraShake shakeCamera;
    private animationScript animationScript;
    //void beg_Sword_Attack_On()
    //{
    //    beg_Sword_Attack_Point.SetActive(true);
    //}

    //void beg_Sword_Attack_Off()
    //{
    //    if(beg_Sword_Attack_Point.activeInHierarchy)
    //    {
    //        beg_Sword_Attack_Point.SetActive(false);
    //    }
    //}

    // Camera Shake
    private void Awake()
    {
        animationScript = FindObjectOfType<animationScript>();
        //shakeCamera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    //void ShakeCameraOnHit()
    //{
        //shakeCamera.setShouldShake(true);
    //}

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

    void leftHandAttack_On()
    {
        Left_Arm_Attack_Point.SetActive(true);
    }

    void leftHandAttack_Off()
    {
        if(Left_Arm_Attack_Point.activeInHierarchy)
        {
            Left_Arm_Attack_Point.SetActive(false);
        }
    }

    void rightHandAttack_On()
    {
        Right_Arm_Attack_Point.SetActive(true);
    }

    void rightHandAttack_Off()
    {
        if(Right_Arm_Attack_Point.activeInHierarchy)
        {
            Right_Arm_Attack_Point.SetActive(false);
        }
    }

    //void MidToEnd_Sword_Attack_On()
    //{
    //    MidToEnd_Sword_Attack_Point.SetActive(true);
    //}

    //void MidToEnd_Sword_Attack_Off()
    //{
    //    if(MidToEnd_Sword_Attack_Point.activeInHierarchy)
    //    {
    //        MidToEnd_Sword_Attack_Point.SetActive(false);
    //    }
    //}

    //void End_Sword_Attack_On()
    //{
    //    End_Sword_Attack_Point.SetActive(true);
    //}

    //void End_Sword_Attack_Off()
    //{
    //    if(End_Sword_Attack_Point.activeInHierarchy)
    //    {
    //        End_Sword_Attack_Point.SetActive(false);
    //    }
    //}

    //void Tag_Beg_Sword_Point()
    //{
    //    beg_Sword_Attack_Point.tag = "beg_Point";
    //}

    //void UnTag_Beg_Sword_Point()
    //{
    //    beg_Sword_Attack_Point.tag = "Untagged";
    //}

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
