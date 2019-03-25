using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiPeHolder : MonoBehaviour {

    public float speed = 3f;

    float X_left;

    // Update is called once per frame
    void Update () {

       _PipeMovement();
        _DeStroy();
        if(TapController.instance!=null)
        {
            if(TapController.instance.flagg==1)
            {
                Destroy(GetComponent<PiPeHolder>());
            }
        }
    }

    void _PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }

    void _DeStroy()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        X_left = temp.x - 10;

        Vector3 posPipe = transform.position;

        if (posPipe.x < X_left)
        {
            Destroy(gameObject);
        }

    }
}
