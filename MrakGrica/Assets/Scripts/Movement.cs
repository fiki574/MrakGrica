using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 100;
    public Rigidbody2D rb;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 tempVect = new Vector2(h, v);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition((Vector2)rb.transform.position + tempVect);
    }
}
