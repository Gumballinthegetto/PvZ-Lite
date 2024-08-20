using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootOrigin;
    public float cooldown;
    public float repeaterDelay; 
    private float lastShootTime;
    public float range;
    public LayerMask shootMask;
    private GameObject target;

    private void Start() {
        lastShootTime = Time.time;
    }

    private void Update() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, shootMask);

        if (hit.collider) {
            target = hit.collider.gameObject;
            Shoot();
        }
    }

    void Shoot() {
        if (Time.time - lastShootTime < cooldown)
            return;
        
        GameObject myBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
        
        Invoke("SpawnSecondBullet", repeaterDelay);
        
        lastShootTime = Time.time;
    }

    void SpawnSecondBullet()
    {
        GameObject secondBullet = Instantiate(bullet, shootOrigin.position, Quaternion.identity);
    }
}
