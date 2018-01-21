﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Rigidbody2D Player;
    public GameObject GunObj;

    void Update()
    {
        if (Input.GetKeyDown("f"))
            if (Player.GetComponent<Collider2D>().IsTouching(GunObj.GetComponent<Collider2D>()))
                Destroy(GunObj);
    }
}