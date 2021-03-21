using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private const int playersLayer = 8;
    private const int bulletPower = 20;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer.Equals(playersLayer))
        {
            collision.gameObject.GetComponent<TankController>().DealDamage(bulletPower);
        }
    }
}
