using UnityEngine;

public class PlayerCntroller : MonoBehaviour
{
    public float moveSpeed;
    float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    float speedIncreaseMilestoneStore;
    float speedMilestoneCount;
   float speedMilestoneCountStore;

    Rigidbody2D myBody;
    public float jumpForce;
    
    public LayerMask whatIsGround;
    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;

    //Collider2D myCollider;
    
    Animator anim;
    public float jumpTime;
    float jumpTimeCounter;
    bool stopedJumping;
    bool canDoubleJump;

    public GameObject puoseButton;

    public GameManager theGameManager;
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;

        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        speedMilestoneCountStore = speedMilestoneCount;
        moveSpeedStore = moveSpeed;

    }
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                stopedJumping = false;
            }
            if (canDoubleJump && !grounded)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                canDoubleJump = false;
                stopedJumping = false;
            }
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) && !stopedJumping)
        {
            if (jumpTimeCounter > 0)
            {
                myBody.velocity = new Vector2(myBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
            stopedJumping = true;
        }
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }       
        anim.SetFloat("Speed", myBody.velocity.x);
        anim.SetBool("Grounded", grounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "KillBox")
        {
            puoseButton.SetActive(false);
            theGameManager.RestartGame();
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            speedMilestoneCount =speedMilestoneCountStore;
            moveSpeed=moveSpeedStore;
        }
    }
}
