using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOver : MonoBehaviour {

    public float lifettime = 3f;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

        lifettime -= Time.deltaTime;

        if(lifettime<0)
        {
            Destroy(gameObject);
           // PlayerController.instance.isShieldActive = false;
        }

	}
}
