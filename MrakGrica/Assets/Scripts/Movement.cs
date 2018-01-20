using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D player;
    private bool facingRight;
    private Animator animator;
	private bool attack;

	[SerializeField]
	private float speed = 4;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
		HandleMovement (h);
		Flip (h);
		HandleInput();
		HandleShoot();
		Reset ();
    }

	private void HandleMovement(float h)
    {
        animator.SetFloat("speed", Mathf.Abs(h));
        player.velocity = new Vector2(h * speed, player.velocity.y);
    }

	private void Flip(float h)
	{
		if (h > 0 && !facingRight || h < 0 && facingRight) 
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private void HandleShoot()
	{
		if(attack)
			animator.SetTrigger("attack");
	}

	private void HandleInput()
	{
		if (Input.GetButtonDown("Fire1"))
			attack = true;
	}

	private void Reset()
	{
		attack = false;
	}

}
