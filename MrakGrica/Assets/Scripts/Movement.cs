using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Player;
    private float speed = 5;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        Vector2 tempVect = new Vector2(h, v);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        Player.MovePosition((Vector2)Player.transform.position + tempVect);
    }
}
