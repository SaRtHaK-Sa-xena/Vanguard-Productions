using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : MonoBehaviour
{
    public float timer = 5f;

    public SphereCollider col;

    public List<ParticleCollisionEvent> collisionEvents;
    public ParticleSystem part;

    // Start is called before the first frame update
    void Start()
    {
    }

    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //col = GameObject.FindGameObjectWithTag("Enemy").GetComponent<SphereCollider>();
        //ParticleSystem particle = GetComponentInChildren<ParticleSystem>();

        //particle.trigger.SetCollider(0, col);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.CompareTag("Enemy"))
        //{
        //    Debug.Log("Particle hit Enemy [Script On Particle]");
        //}
        //Debug.Log("Touched");
    }

    private void OnParticleCollision(GameObject other)
    {
        // If Enemy
        if (other.CompareTag("Enemy"))
        {
            DeactivateAfterTime();
            Debug.Log("Enemy Struck");
        }
    }
}
