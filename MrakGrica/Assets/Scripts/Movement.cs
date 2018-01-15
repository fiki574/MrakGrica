using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D Player;
    private float speed = 6;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        animator.SetFloat("speed", Mathf.Abs(h));
        Vector2 tempVect = new Vector2(h, v);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        Player.MovePosition((Vector2)Player.transform.position + tempVect);

    }
}
