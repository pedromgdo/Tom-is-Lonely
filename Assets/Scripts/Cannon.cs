using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float fireRate = 1f;
    private float lastShot = 0f;
    public Vector3 offset;
    public GameObject bullet;
    public dir shootDirection;
    // Update is called once per frame
    private void Awake() {
        lastShot = fireRate;
    }
    void Update()
    {
        if (lastShot >= fireRate) {
            ShootBullet();
            lastShot = 0f;
        }
        else {
            lastShot += Time.deltaTime;
        }
    }
    private void ShootBullet() {
        GameObject projectile = Instantiate(bullet, transform.position+offset, Quaternion.identity);
        projectile.GetComponent<Projectile>().shootDirection(shootDirection);
    }
    
}
