using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns in Fragments
/// </summary>
public class fragSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject memoryFrag;

    public Sprite[] Sprites;

    public Sprite finalSprite;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        // spawn fragment in each spawnpoint
        foreach(Transform spawn in spawnPoints)
        {
            GameObject frag = Instantiate(memoryFrag, spawn);
            frag.GetComponent<fragmentInteraction>().sprite = Sprites[i];
            i++;
        }
    }

    // spawned when the player finds the postman
    public void SpawnFinalMemory(Transform position)
    {
        GameObject frag = Instantiate(memoryFrag, position);
        frag.GetComponent<fragmentInteraction>().sprite = finalSprite;
    }
}
