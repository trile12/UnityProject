using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public Rigidbody2D rb;

    public GameObject player2;

	// Use this for initialization
	void Start () {

       rb = GetComponent<Rigidbody2D>();       

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
