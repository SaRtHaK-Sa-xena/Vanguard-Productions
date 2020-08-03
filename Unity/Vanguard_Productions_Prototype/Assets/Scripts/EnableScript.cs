using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<EnemyMovement>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<EnemyMovement>().enabled = false;
        }
    }
}
