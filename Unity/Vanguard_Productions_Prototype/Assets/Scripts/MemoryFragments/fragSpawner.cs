using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject memoryFrag;

    public Sprite[] Sprites;

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
}
