using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Unity Stuff")]
    public Rigidbody2D body;
    public Animator anim;
    public ParticleSystem deathParticles;
    [Header("Attributes")]
    public float speed = 5f;
    public float jumpForce = 10f;
    public const float jumpDelay = 0.1f;
    public int numberOfJumps = 1;
    [Header("Helpers")]
    public bool blockMovement = false;
    //Helping stuff, words are hard
    private Vector2 movement;
    private int currentJumps = 0;
    private float jumpTime = 0.1f;
    private Vector3 m_Velocity = Vector3.zero;

    void Start()
    {
        if (body == null) body = GetComponent<Rigidbody2D>();
        if (anim == null) anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            ReloadLevel();
        }
        if (!blockMovement) {
            movement.x = Input.GetAxis("Horizontal");
            if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.UpArrow)) {
                if (jumpTime >= jumpDelay) {
                    Jump();
                    jumpTime = 0f;
                }
            }
            else {
                jumpTime += Time.deltaTime;
            }
            anim.SetFloat("moveSpeed", Mathf.Abs(movement.x));
            if (movement.x >= 0) transform.rotation = Quaternion.identity;
            else transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else {
            body.gravityScale = 2;
            body.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void LateUpdate() {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(movement.x * 10f, body.velocity.y);
        // And then smoothing it out and applying it to the character
        body.velocity = Vector3.SmoothDamp(body.velocity, targetVelocity, ref m_Velocity, 0.1f);

        //body.AddForce(movement*speed*Time.fixedDeltaTime*100);
        //body.MovePosition(body.position + (movement*speed*Time.fixedDeltaTime));
    }

    private void Jump() {
        if (currentJumps < numberOfJumps) {
            AudioManager.instance.Play("jump_1");
            body.velocity = Vector2.zero;
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentJumps += 1;
        }
        else {
            Debug.Log("Cannot jump again because you reached the maximum number of jumps");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        switch (collision.collider.tag) {
            case "Ceiling":
                break;
            case "Floor":
                currentJumps = 0;
                jumpTime = 0.1f;
                break;
            case "Wall":
                currentJumps = 0;
                jumpTime = 0.1f;
                break;
            case "InstantDeath":
                blockMovement = true;
                anim.SetFloat("moveSpeed", 0);
                Die();
                break;
            default:
                currentJumps = 0;
                jumpTime = 0.1f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        switch (collision.tag) {
            case "InstantDeath":
                blockMovement = true;
                anim.SetFloat("moveSpeed", 0);
                Die();
                break;
            default:
                break;
        }
    }

    private void Die() {
        AudioManager.instance.Play("death_1");
        PlayerPrefs.SetInt("nrDeaths",PlayerPrefs.GetInt("nrDeaths",0)+1);
        if (UImanager.instance != null) UImanager.instance.updateTexts();
        transform.localScale = Vector3.zero;
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Invoke("ReloadLevel", 1f);
    }
    private void ReloadLevel() {
        MenuController.reloadCurrentLevel();
    }
}
