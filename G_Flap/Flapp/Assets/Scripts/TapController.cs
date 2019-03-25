using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TapController : MonoBehaviour {


    private Object spawner;

    
    public Text bestScore;

    public static TapController instance;


    public float tapForce = 10f;
    public float tiltSmooth = 5f;
    public Vector3 startPos;

    public Image overImage;
    
    

    private bool isAlive;
    private bool didFlap;
        

    public Rigidbody2D rb;
    public Animator anim;
    Quaternion downRotation;
    Quaternion forwardRotation;

    [SerializeField]
    private Button againButton;



    public float flagg = 0;
    public int score = 0;

    void Awake()
    {
        isAlive = true;
        _MakeInstance();
        spawner = GameObject.Find("PipeSpawn");
        bestScore.GetComponent<Text>().text = PlayerPrefs.GetInt("High Score").ToString();
    }


    void Start () {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
            downRotation = Quaternion.Euler(0, 0, -90);
        
        forwardRotation = Quaternion.Euler(0, 0, 35);
  

		
	}

    void _MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
       
        _BirdFly();
        if (flagg == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
        }
        
    }

    void _BirdFly()
    {
        //if(isAlive)
        //{
        //    if (didFlap && flagg == 0) 
        //    {
        //        didFlap = false;
        //        transform.rotation = forwardRotation;
        //        rb.velocity = Vector3.zero;
        //        rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        //    }
        //}

        if(Input.GetMouseButtonDown(0))
        {
            transform.rotation = forwardRotation;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
    }

    public void _FlapButton()
    {
        didFlap = true;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="ScoreZone")
        {

            //Score
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._SetScore(score);
            }
            //Debug.Log("score=" + score);
        }
    }


    
    void OnCollisionEnter2D(Collision2D col)
    {
       

        if(col.collider.tag=="DeadZone")
        {
            flagg = 1;
            anim.SetBool("Fly", true);
           
            Destroy(spawner);
            overImage.GetComponent<Image>().enabled = true;
            //Time.timeScale = 0;
            againButton.gameObject.SetActive(true);

            if(score>GamePlayController.instance._GetHighScore())
            {
                GamePlayController.instance._SetHighScore(score);
            }
           
                bestScore.text = GamePlayController.instance._GetHighScore().ToString();
           
            
            
            
            //DeadZone
        }
    }

    public void _AgainButton()
    {

        Application.LoadLevel("SampleScene");
    }

    


}
