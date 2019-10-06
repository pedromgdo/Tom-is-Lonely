using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed;
    public Rigidbody2D body;

    public void shootDirection(dir direction) {
        switch (direction) {
            case dir.UP:
                updateVelocity(Vector2.up);
                break;
            case dir.DOWN:
                updateVelocity(Vector2.down);
                break;
            case dir.LEFT:
                updateVelocity(Vector2.left);
                break;
            case dir.RIGHT:
                updateVelocity(Vector2.right);
                break;
            default:
                Debug.Log("Something went wrong in the bullet");
                break;
        }
    }
    public void updateVelocity(Vector2 targetVelocity) {
        body.velocity = targetVelocity * speed;
    }
}

public enum dir { UP, LEFT, RIGHT, DOWN }
