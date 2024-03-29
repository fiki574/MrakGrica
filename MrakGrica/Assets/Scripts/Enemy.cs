﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float Health, timer;
    private Animator animator;
    private int moveSpeed, rotationSpeed;
    private Transform target, myTransform;
    
    private bool facingRight;

    void Awake()
    {
        myTransform = transform;
    }

    void Start ()
    {
        moveSpeed = 1;
        rotationSpeed = 0;
        Health = 100;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        facingRight = true;
    }

    void Update()
    {
        Vector2 dir = target.position - myTransform.position;
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.FromToRotation(Vector3.right, dir), rotationSpeed * Time.deltaTime);
        myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;

        animator.SetFloat("ZombieSpeed", Mathf.Abs(target.position.x - myTransform.position.x));
        Flip(target.position.x - myTransform.position.x);

        RaycastHit2D detect_right, detect_left;
        Rigidbody2D zombie = gameObject.GetComponent<Rigidbody2D>(), player_left, player_right;

        detect_right = Physics2D.Raycast(new Vector2(zombie.position.x + 0.65f, zombie.position.y), new Vector2(zombie.position.x + 0.7f, zombie.position.y));
        detect_left = Physics2D.Raycast(new Vector2(zombie.position.x - 0.65f, zombie.position.y), new Vector2(zombie.position.x - 0.7f, zombie.position.y));

        player_right = detect_right.collider.GetComponent<Rigidbody2D>();
        player_left = detect_left.collider.GetComponent<Rigidbody2D>();

        bool valid_right = player_right.ToString().Contains("Player"), valid_left = player_left.ToString().Contains("Player");

        PlayCont player;
        if (valid_right)
            player = player_right.GetComponent<PlayCont>();
        else if (valid_left)
            player = player_left.GetComponent<PlayCont>();
        else
            player = null;

        if (timer > 0)
            timer -= Time.deltaTime;

        if (player != null)
        {
            if (timer <= 0)
            {
                animator.SetTrigger("PlayerClose");
                player.TakeDamage(15.0f);
                timer = 2.0f;
            }
        }
    }


    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0.0f)
            Health = 0.0f;
    }

    public float GetHealth()
    {
        return Health;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void Flip(float h)
    {
        if (h > 0 && !facingRight || h < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = myTransform.localScale;
            theScale.x *= -1;
            myTransform.localScale = theScale;
        }
    }
}
