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

    public void setNextSprite()
    {
        if(spriteNum < memoryFragments.Length)
        {
            currentMemory = memoryFragments[spriteNum];
            spriteNum++;
        }
    }
}