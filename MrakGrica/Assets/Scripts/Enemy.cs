using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float Health;

	void Start ()
    {
        Health = 100;
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
