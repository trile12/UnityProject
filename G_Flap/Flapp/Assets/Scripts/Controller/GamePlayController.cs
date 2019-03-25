using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Image imageInstruction;

    [SerializeField]
    private Text scoreInstruction;

    [SerializeField]
    private Text scoreText;

    private const string HIGH_SCORE = "High Score"; 


  


    public static GamePlayController instance;




    void Awake()
    {
        Time.timeScale = 0;
        _MakeInstance();
       

    }


    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void _IntructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
        imageInstruction.gameObject.SetActive(false);
        scoreText.GetComponent<Text>().enabled = true;
        
      
    }
    
    public void _SetScore(int score)
    {
        scoreText.text = score.ToString();

       
    }

    public void _SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    
    public int _GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
    public void OnFirstPlay()
    {

    }



}
