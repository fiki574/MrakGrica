using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody2D player;
    private bool facingRight;
    private Animator animator;
	private bool attack;

    public Text Score;

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
		HandleInput();
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
		HandleMovement(h);
		Flip(h);
		HandleShoot();
		Reset();
    }

	private void HandleMovement(float h)
    {
		if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Shoot")) 
		{
			player.velocity = new Vector2(h * speed, player.velocity.y);
		}
		animator.SetFloat("speed", Mathf.Abs(h));
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
		if (attack) 
		{
			animator.SetTrigger ("attack");
			player.velocity = Vector2.zero;

            //zvuk pucanja

            RaycastHit2D hit;
            if (facingRight)
                hit = Physics2D.Raycast(new Vector2(player.position.x + 2f, player.position.y - 0.5f), new Vector2(player.position.x + 100f, player.position.y - 0.5f));
            else
                hit = Physics2D.Raycast(new Vector2(player.position.x - 2f, player.position.y - 0.5f), new Vector2(player.position.x - 100f, player.position.y - 0.5f));

            bool valid = hit.collider.GetComponent<Rigidbody2D>().ToString().Contains("Zombie");
            if (valid)
            {
                Enemy zombie = hit.collider.GetComponent<Enemy>();
                zombie.TakeDamage(35f);
                if (zombie.GetHealth() == 0.0f)
                {
                    int score = System.Convert.ToInt32(Score.text.Remove(0, 8));
                    score += 50;
                    Score.text = "POINTS: " + score;
                    zombie.Kill();
                }
            }
        }
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
