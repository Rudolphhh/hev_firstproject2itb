using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangedEnemy : MonoBehaviour, IDamagable
{
    private int hp;
    [SerializeField]
    private int MaxHp;
    
    private MeleeEnemy mel;

    public Transform player;

    public float moveSpeed = 1f;
    [SerializeField]
    public GameObject bulletPrefab;
    [SerializeField]
    public Transform shooter;


    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        InvokeRepeating("FollowAndShoot", 2f, 2f);
    }

    void Update()
    {
        
        

        
        transform.LookAt(player);
    }
    

    void FollowAndShoot()
    {
        if (player != null)
        {
            
            

            
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, shooter.position, shooter.rotation);

        
        Vector3 shootDirection = (player.position - shooter.position).normalized;

        
        bullet.GetComponent<Rigidbody>().AddForce(shootDirection * 100f, ForceMode.Impulse);

        
    }

    public void Die()
    {
        var sc = FindObjectOfType<TPSScore>();
        sc.AddScore();
        
        Destroy(gameObject);
    }

    public void DoDmg(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0)
        {
            
            Die();
        }
    }
}