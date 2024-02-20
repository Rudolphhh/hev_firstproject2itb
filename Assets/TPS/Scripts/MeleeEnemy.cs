using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour, IDamagable
{
    private int hp;
    [SerializeField]
    private int MaxHp;
    
    
    public int skore;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
    
    public Transform player;
    
    public float moveSpeed = 1f;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void DoDmg(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0)
        {
            var sc = FindObjectOfType<TPSScore>();
            sc.AddScore();
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        
        if (player != null)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            
            transform.LookAt(player);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var pc = collision.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            if (PlayerController.isHit)
            {
                PlayerController.GameOver();
            }
            else
            {
                PlayerController.isHit = true;
            }


        }
    }
}


