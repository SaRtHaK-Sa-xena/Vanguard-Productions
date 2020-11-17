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

    // rumble dialogue
    public RumbleDialogue rumbleDialogue;

    public void setNextSprite()
    {
        if(spriteNum < memoryFragments.Length)
        {
            currentMemory = memoryFragments[spriteNum];
            spriteNum++;
        }

        if(spriteNum >= 4)
        {
            // rumbleDialogue script start
            rumbleDialogue.ShakeCamera(10f, .1f);
        }
    }
}