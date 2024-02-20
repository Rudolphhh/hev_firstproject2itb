using System;
using UnityEngine;

public class DamageToPlay : MonoBehaviour
{
    

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") || (other.CompareTag("Enemy") && other.gameObject.tag != "Player"))
        {
            Debug.Log("dsaadsads");
            Destroy(other.gameObject);
        }
    }
}