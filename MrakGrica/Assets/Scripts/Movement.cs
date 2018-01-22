using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody2D player;
    private bool facingRight;
    private Animator animator;
	private bool attack;
    private AudioSource audioShoot;
    private AudioSource audioReload;
    private int mag;
    private bool reload;

    public Text Score;

	[SerializeField]
	private float speed = 4;

    [SerializeField]
    private AudioClip gunShoot;

    [SerializeField]
    private AudioClip gunReload;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        facingRight = true;
        mag = 7;
    }
	private void Update()
	{
		HandleInput();
	}

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
		HandleMovement(h);
		Flip(h);
		HandleShoot();
        HandleReload();
		Reset();
    }

    private void Awake()
    {
        audioShoot = AddAudio(gunShoot, false, false, 0.75f);
        audioReload = AddAudio(gunReload, false, false, 0.75f);
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
            audioShoot.Play();

            if (mag > 1)
                mag--;
            else if (mag == 1)
                reload = true;

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
        if (Input.GetKeyDown("r"))
            reload = true;
	}

	private void Reset()
	{
		attack = false;
        reload = false;
    }

    private AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;

    }

    private void HandleReload()
    {
        if (reload)
        {
            animator.SetTrigger("reload");

            player.velocity = Vector2.zero;

            audioReload.Play();

            mag = 7;
        }
    } 

}
