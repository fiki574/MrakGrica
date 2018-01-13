using UnityEngine;

public class Doors : MonoBehaviour
{
    public string ID;
    public Rigidbody2D Player;
    private bool CanTeleport;

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
        {
            if (CanTeleport)
            {
                switch (ID)
                {
                    case "KPV1":
                        {
                            Player.transform.position = new Vector2(18.5f, -5.9f);
                            break;
                        }

                    case "K0V1":
                        {
                            Player.transform.position = new Vector2(18.5f, -1.2f);
                            break;
                        }

                    case "K0V2":
                        {
                            Player.transform.position = new Vector2(18.5f, -12.6f);
                            break;
                        }

                    case "K1V1":
                        {
                            Player.transform.position = new Vector2(18.5f, 3.75f);
                            break;
                        }

                    case "K1V2":
                        {
                            Player.transform.position = new Vector2(9.2f, -5.8f);
                            break;
                        }

                    case "K2V1":
                        {
                            Player.transform.position = new Vector2(0.0f, 8.5f);
                            break;
                        }

                    case "K2V2":
                        {
                            Player.transform.position = new Vector2(0.0f, -1.15f);
                            break;
                        }

                    case "K3V1":
                        {
                            Player.transform.position = new Vector2(0.0f, 3.7f);
                            break;
                        }
                }
            }
        }
    }
}
