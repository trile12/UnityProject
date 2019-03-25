using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour {

    public float snowBallSpeed;

    public Rigidbody2D rb;
    public GameObject snowBallEffect;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
      //  snowBallEffect = FindObjectOfType("SnowBallEffect");

	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(snowBallSpeed * transform.localScale.x, 0);
		
	}

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();

        }
        if(collision.tag=="Player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
        Instantiate(snowBallEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
