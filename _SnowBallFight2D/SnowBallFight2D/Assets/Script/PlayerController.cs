using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumForce;

    private Rigidbody2D rb;
    private Animator anim;

 

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Transform throwPos;
    public Transform shieldPos;
    public GameObject snowBall;

    public GameObject shield;


    public bool isGrounded;
    public bool isShieldActive;

    public static PlayerController instance;

    



	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		
	}

    void MakeInstance()
    {
        if(instance!=null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        MoveController();
        //StartCoroutine(waitSecond(2));


    }
    public void MoveController()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject GO = Instantiate(snowBall, throwPos.position, throwPos.rotation);

            GO.transform.localScale = transform.localScale;

            anim.SetTrigger("Throw");
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumForce);
        }
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.K) && isShieldActive == false)
        {
            shield.SetActive(true);

            GameObject ShieldScale = Instantiate(shield, shieldPos.position, shieldPos.rotation);
            ShieldScale.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            isShieldActive = true;
        }
    }

    //IEnumerator waitSecond(float seconds)
    //{
    //    yield return new WaitForSeconds(seconds);

    //    isShieldActive = false;
    //}
}
