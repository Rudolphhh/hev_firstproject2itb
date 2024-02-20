using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
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
            Destroy(this.gameObject);

        }

    }
}
