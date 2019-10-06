using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile {
    private Rigidbody2D player;
    // Start is called before the first frame update

    public void Start() {
        body.velocity = Vector3.zero;
        Destroy(gameObject, 20f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        if (player == null) Debug.LogError("No Player Found");
    }

    private void Update() {
        if (player != null) {
            body.position = Vector3.MoveTowards(body.position, player.position, speed * Time.deltaTime);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag != "InstantDeath")
            Destroy(gameObject);
    }
}
