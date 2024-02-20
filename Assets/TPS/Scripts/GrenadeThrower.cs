using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40f;

    public GameObject grenadePrefab;

    public Transform handTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Invoke("ThrowGrenade", 1f);
        }
    }

    void ThrowGrenade()
    {
        Vector3 spawnPosition = handTransform.position;


        GameObject grenade = Instantiate(grenadePrefab, spawnPosition, handTransform.rotation);



        //GameObject grenade = Instantiate(grenadePrefab,transform.position, transform.rotation);

        Rigidbody rb = grenade.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
