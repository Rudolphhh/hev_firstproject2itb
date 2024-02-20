using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 11f;
    public float force = 700f;
    public int damage = 40;
    

    float countDown;
    bool hasExploded = false;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float distancedamage;

                float distance = Vector3.Distance(transform.position, rb.transform.position);

                distancedamage = 100/distance;

                rb.AddExplosionForce(force, transform.position, radius);

                var dmg = rb.GetComponent<IDamagable>();
                if (dmg != null)
                {
                    dmg.DoDmg((int)distancedamage);
                }
            }
        }

        Debug.Log("BOOM");
        Destroy(gameObject);
    }
}
