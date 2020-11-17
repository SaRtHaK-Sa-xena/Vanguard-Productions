using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  
/// </summary>
public class memoryManager : MonoBehaviour
{
    public Sprite[] memoryFragments;

    public Sprite currentMemory;

    public int spriteNum;

    // colliders to check if the rumble should begin
    public GameObject boxCollider_A;
    public GameObject boxCollider_B;

    public void setNextSprite()
    {
        if(spriteNum < memoryFragments.Length)
        {
            currentMemory = memoryFragments[spriteNum];
            spriteNum++;
        }

        if(spriteNum >= 4)
        {
            // enable box colliders
            boxCollider_A.gameObject.SetActive(true);
            boxCollider_B.gameObject.SetActive(true);
        }
    }
}