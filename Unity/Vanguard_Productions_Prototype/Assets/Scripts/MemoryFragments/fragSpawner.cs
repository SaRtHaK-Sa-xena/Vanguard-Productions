using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject memoryFrag;

    // Start is called before the first frame update
    void Start()
    {
        // spawn fragment in each spawnpoint
        foreach(Transform spawn in spawnPoints)
        {
            GameObject frag = Instantiate(memoryFrag, spawn);
        }
    }
}
