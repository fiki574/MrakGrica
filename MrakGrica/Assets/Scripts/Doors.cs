﻿using UnityEngine;

public class Doors : MonoBehaviour
{
    public string ID;
    public Rigidbody2D Player;
    public SpriteRenderer Sprite;
    public AudioSource DoorsOpen, DoorsClose;
    private bool CanTeleport = false, Pressed = false, Faded = false;
    private float minimum = 0.0f, maximum = 1f, speed = 1.5f, threshold = 0.05f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        CanTeleport = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        CanTeleport = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
            if (CanTeleport)
            {
                Pressed = true;
                Player.constraints = RigidbodyConstraints2D.FreezeAll;
                DoorsOpen.Play();
            }
                
        float step = speed * Time.deltaTime;
        if (Pressed && !Faded)
        {
            Sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(Sprite.color.a, minimum, step));
            if (Mathf.Abs(Sprite.color.a - minimum) <= threshold)
            {
                Faded = true;
                Teleport();
            }
        }

        if (!Pressed && Faded)
        {
            Sprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(Sprite.color.a, maximum, step));
            if (Mathf.Abs(maximum - Sprite.color.a) <= threshold)
                Faded = false;
        }
    }

    private void Teleport()
    {
        if (ID == "KPV1")
            Player.transform.position = new Vector2(18.5f, -5.9f);
        else if (ID == "K0V1")
            Player.transform.position = new Vector2(18.5f, -1.2f);
        else if (ID == "K0V2")
            Player.transform.position = new Vector2(18.5f, -12.6f);
        else if (ID == "K1V1")
            Player.transform.position = new Vector2(18.5f, 3.75f);
        else if (ID == "K1V2")
            Player.transform.position = new Vector2(9.2f, -5.8f);
        else if (ID == "K2V1")
            Player.transform.position = new Vector2(0.0f, 8.5f);
        else if (ID == "K2V2")
            Player.transform.position = new Vector2(0.0f, -1.15f);
        else if (ID == "K3V1")
            Player.transform.position = new Vector2(0.0f, 3.7f);
        else if (ID == "K0O1")
            Player.transform.position = new Vector2(-3.49f, -11.6f);
        else if (ID == "K-1O1")
            Player.transform.position = new Vector2(11.66f, -4.53f);
        else if (ID == "K-1O2")
            Player.transform.position = new Vector2(-3.43f, -18.2f);
        else if (ID == "K-2O1")
            Player.transform.position = new Vector2(11.82f, -11.4f);
        else if (ID == "K-2O2")
            Player.transform.position = new Vector2(-3.5f, -25.8f);
        else if (ID == "K-3O1")
            Player.transform.position = new Vector2(11.64f, -18.3f);

        Pressed = false;
        Player.constraints = RigidbodyConstraints2D.FreezeRotation;
        DoorsClose.Play();
    }
}
