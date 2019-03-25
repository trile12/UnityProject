using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

    public int P1life;
    public int P2life;

    public GameObject gameOver;

    public GameObject[] P1Sticks;
    public GameObject[] P2Sticks;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(P1life<=0)
        {
            player1.SetActive(false);
            gameOver.SetActive(true);
        }
        if (P2life <= 0)
        {
            player2.SetActive(false);
            gameOver.SetActive(true);
        }
    }

    public void HurtP1()
    {
        P1life -= 1;
        for(int i=0;i<P1Sticks.Length;i++)
        {
            if(P1life>i)
            {
                P1Sticks[i].SetActive(true);
            }
            else
            {
                P1Sticks[i].SetActive(false);
            }
        }
    }

    public void HurtP2()
    {
        P2life -= 1;
        for(int i=0;i<P2Sticks.Length;i++)
        {
            if(P2life>i)
            {
                P2Sticks[i].SetActive(true);

            }
            else
            {
                P2Sticks[i].SetActive(false);
            }
        }
    }

}
