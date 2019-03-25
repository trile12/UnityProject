using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScale : MonoBehaviour {

	// Use this for initialization
	void Start () {

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempScale = transform.localScale;

        float height = sr.bounds.size.y;
        // float width = sr.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWith = worldHeight * Screen.width / Screen.height;

        tempScale.y = worldHeight / height;

        transform.localScale = tempScale;



		
	}
	

}
