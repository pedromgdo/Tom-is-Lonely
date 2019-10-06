using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : Projectile {
    // Start is called before the first frame update

    public void Start() {
        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag != "InstantDeath")
            Destroy(gameObject);
    }
}
