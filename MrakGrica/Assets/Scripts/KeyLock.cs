using UnityEngine;

public class KeyLock : MonoBehaviour
{
    public Rigidbody2D Player;
    public GameObject Exit, Key;
    public AudioSource DoorsOpen;
    private bool HasKey = false;

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (Player.GetComponent<Collider2D>().IsTouching(Exit.GetComponent<Collider2D>()) && HasKey)
            {
                Destroy(Exit);
                DoorsOpen.Play();
            }

            if (Key != null)
            {
                if (Player.GetComponent<Collider2D>().IsTouching(Key.GetComponent<Collider2D>()) && !HasKey)
                {
                    Destroy(Key);
                    HasKey = true;
                }
            }
        }
    }
}
