using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;

    public void Shoot()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        
        bullet1.GetComponent<Bullet>().SpawnAdditionalBullet();
    }
}
