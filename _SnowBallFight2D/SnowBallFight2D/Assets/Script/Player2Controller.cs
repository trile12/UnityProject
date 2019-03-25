using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    public float moveSpeed;
    public float jumForce;

    private Rigidbody2D rb;
    private Animator anim;
    public KeyCode Shoot;
 

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Transform throwPos;
    public GameObject snowBall;
    public GameObject shield;
    public Transform shieldPos;

    public float timeShield = 2f;

    public bool isGrounded;
    public bool isActiveShield=false;



	// Use this for initialization
	void Start () {

        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        shield.transform.position = rb.transform.position;
     
        
       if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
       else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
       if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            GameObject GO= Instantiate(snowBall, throwPos.position, throwPos.rotation);

            GO.transform.localScale = transform.localScale;

            anim.SetTrigger("Throw");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x,jumForce);
        }
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Keypad2)) 
        {
            shield.SetActive(true);
           GameObject ShieldScale= Instantiate(shield, shieldPos.position, shieldPos.rotation);
            ShieldScale.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            
        }

    }
}
