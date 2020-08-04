using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float power = 0.1f;
    public float duration = 0.1f;
    private float slowDownAmount = 1f;
    public bool shouldShake;
    private float initialDuration;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
       Shake();
       startPosition = transform.localPosition;
    }

    void Shake()
    {
        if(shouldShake)
        {
            if (duration > 0f)
            {
                transform.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = startPosition;
            }
        }
    }

    public bool getShouldShake()
    {
        return shouldShake; 
    }

    public void setShouldShake(bool state)
    {
        shouldShake = state;
    }

}
