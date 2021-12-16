using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Use SerializeField if you want private variables to be seen in the inspection panel in Unity
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private int playerScore;
    private string CHEST_TAG = "Chest";
    private int CHEST_SCORE = 1000;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        // The player is moving to the right side
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        // The player is moving to the left side
        else if(movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        } 

        // Checks to see if player collides with chest and if so, updates the score
        if(collision.gameObject.CompareTag(CHEST_TAG))
        {
            PlayerScore += CHEST_SCORE;
        }
    }

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

}
