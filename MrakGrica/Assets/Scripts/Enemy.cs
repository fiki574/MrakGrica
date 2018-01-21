using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float Health;
    private Animator animator;
    private float timer;

    void Start ()
    {
        Health = 100;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D detect_right, detect_left;
        Rigidbody2D zombie = gameObject.GetComponent<Rigidbody2D>(), player_left, player_right;

        detect_right = Physics2D.Raycast(new Vector2(zombie.position.x + 2.0f, zombie.position.y), new Vector2(zombie.position.x + 3.0f, zombie.position.y));
        detect_left = Physics2D.Raycast(new Vector2(zombie.position.x - 2.0f, zombie.position.y), new Vector2(zombie.position.x - 3.0f, zombie.position.y));

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
        {
            timer -= Time.deltaTime;
        }

        if (player != null)
        {
            if (timer <= 0)
            {
                animator.SetTrigger("PlayerClose");
                player.TakeDamage(15.0f);
                timer = 2.0f;
                //promijenit ovo nekak pošto brzo skida health zbog Update() brzine
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
}
