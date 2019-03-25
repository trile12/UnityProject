using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScore : MonoBehaviour {

    public Text hightscore;

    void Start()
    {
        hightscore = GetComponent<Text>();
        hightscore.text = PlayerPrefs.GetInt("HightScore").ToString();
    }

}
