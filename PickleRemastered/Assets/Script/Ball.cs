using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Ball : MonoBehaviour {

    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;
    public bool ThrowRight = true;
    public bool ThrowLeft = false;
    public string BallPosition = "Right";
    public string RunnerPosition = "Center";
    public string RunnerLastPosition = "Center";

    public AnimationClip LIdle;

    float speed = 8f;

    Rigidbody2D RB;

    public Animator LBasemanAnim;
    public Animator RBasemanAnim;

    public string[] LeftIdleAnimations;
    public string[] LeftThrowAnimations;

    public string[] RightIdleAnimations;
    public string[] RightThrowAnimations;

    public GameObject Runner;
    public Transform LL;
    public Transform L;
    public Transform R;
    public Transform RR;
    public int rand;

    float RightBasePosition = 5.5f;
    float LeftBasePosition = -5.5f;
    public int score;
    public Text txtScore;
    public Text txtAstroScore;
    bool scoredPoint = false;

    public int unlockIndex = -1;

    public Sprite[] Balls;
    public int[] BallScores;

    public Sprite[] Runners;
    public int[] RunnerScores;

    public Sprite[] Basemen;
    public int[] BasemenScores;

    public int AstroField = 28;
    public Sprite Astro;

    public Text txtUnlock;
    public SpriteRenderer UnlockSprite;
    public GameObject UnlockSpriteGO;
    public GameObject UnlockLock;

    // Use this for initialization
    void Start () {
        LBasemanAnim.SetInteger("LInt", PlayerPrefs.GetInt("PlayingBasemen"));
        RBasemanAnim.SetInteger("RInt", PlayerPrefs.GetInt("PlayingBasemen"));
        RB = GetComponent<Rigidbody2D>();
        //Testing 
        //PlayerPrefs.SetInt("PlayerNum",1);

        score = 0;
        InvokeRepeating("SetRandomNumber", 1f, 2f);
        UnlockLock.SetActive(false);
        UnlockSpriteGO.SetActive(false);
        //PlayerPrefs.SetInt("PlayingBasemen",3);
    }

    // Update is called once per frame
    void Update () {

        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            ballMove();
        }
        if (ThrowLeft == false && ThrowRight == false)
        {
            if (PlayerPrefs.GetInt("PlayerNum") == 2)
            {
                TwoPlayer();
            }
            if (PlayerPrefs.GetInt("PlayerNum") == 1)
            {
                //OnePlayer
                if (Runner.transform.position.x < LL.position.x)
                {
                    //Ball Needs to be left
                    BallLeft();
                }
                if (Runner.transform.position.x > RR.position.x)
                {
                    //Ball Needs to be left
                    BallRight();
                }
                if (RunnerPosition == "Center" && RunnerLastPosition == "Right")
                {
                    if (rand == 1)
                    {
                        BallLeft();
                    }
                }
                if (RunnerPosition == "Center" && RunnerLastPosition == "Left")
                {
                    if (rand == 1)
                    {
                        BallRight();
                    }
                }
                if (RunnerPosition == "Left" && RunnerLastPosition == "Center")
                {
                    if (rand == 2)
                    {
                        BallLeft();
                    }
                }
                if (RunnerPosition == "Right" && RunnerLastPosition == "Center")
                {
                    if (rand == 2)
                    {
                        BallRight();
                    }
                }
            }
        }
        SetBasemanAnimation(LBasemanAnim,"LBasemanThrow", ThrowRight);
        SetBasemanAnimation(RBasemanAnim, "RBasemanThrow", ThrowLeft);
        SetBallPosition();
        SetRunnerPosition();

        if (scoredPoint == false)
        {
            if (Runner.transform.position.x >= RightBasePosition || Runner.transform.position.x <= LeftBasePosition)
            {
                ScorePoint();
            }
        }
        if (Runner.transform.position.x < RightBasePosition && Runner.transform.position.x > LeftBasePosition)
        {
            scoredPoint = false;
        }

        //Speed up ball
        SpeedUp(5,8f,9f);
        SpeedUp(10, 9f, 10f);
        SpeedUp(15, 10f, 11f);
        SpeedUp(30, 11f, 12f);
        SpeedUp(70, 12f, 13f);
        SpeedUp(100, 13f, 15f);
        SpeedUp(120, 15f, 18f);

        //Out
        if (Runner.transform.position.x > RightBasePosition && currentWayPoint == 7)
        {
            Out();
        }
        if (Runner.transform.position.x < LeftBasePosition && currentWayPoint == 0)
        {
            Out();
        }

        //Set High Score
        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        //Unlock Display
        if (scoredPoint)
        {
            if (UnlockLock.activeInHierarchy)
            {
                UnlockLock.SetActive(false);
                UnlockSpriteGO.SetActive(false);
            }

            unlockIndex = Array.IndexOf(BallScores, score);
            if(unlockIndex != -1 && PlayerPrefs.GetInt("HighScore") <= score)
            {
                UnlockLock.SetActive(true);
                UnlockSpriteGO.SetActive(true);
                txtUnlock.text = BallScores[unlockIndex].ToString();
                UnlockSprite.sprite = Balls[unlockIndex];
                UnlockSpriteGO.transform.localScale = new Vector2(8,8);
            }
            unlockIndex = Array.IndexOf(RunnerScores, score);
            if (unlockIndex != -1 && PlayerPrefs.GetInt("HighScore") <= score)
            {
                UnlockLock.SetActive(true);
                UnlockSpriteGO.SetActive(true);
                txtUnlock.text = RunnerScores[unlockIndex].ToString();
                UnlockSprite.sprite = Runners[unlockIndex];
                UnlockSpriteGO.transform.localScale = new Vector2(3.8f, 3.3f);
            }
            unlockIndex = Array.IndexOf(BasemenScores, score);
            if (unlockIndex != -1 && PlayerPrefs.GetInt("HighScore") <= score)
            {
                UnlockLock.SetActive(true);
                UnlockSpriteGO.SetActive(true);
                txtUnlock.text = BasemenScores[unlockIndex].ToString();
                UnlockSprite.sprite = Basemen[unlockIndex];
                UnlockSpriteGO.transform.localScale = new Vector2(3.8f, 3.3f);
            }
        }

        if (unlockIndex == -1 && score == AstroField && PlayerPrefs.GetInt("HighScore") <= score)
        {
            UnlockLock.SetActive(true);
            UnlockSpriteGO.SetActive(true);
            txtUnlock.text = AstroField.ToString();
            UnlockSprite.sprite = Astro;
            UnlockSpriteGO.transform.localScale = new Vector2(0.45f, 0.45f);
        }

    }
    void ballMove()
    {
        // move towards the target
        RB.transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (ThrowRight)
        {
            if (RB.transform.position == targetWayPoint.position && currentWayPoint != 7)
                    {
                        currentWayPoint++;
                        targetWayPoint = wayPointList[currentWayPoint];
                    }
            if(currentWayPoint == 7)
            {
                ThrowRight = false;
            }
        }
        if (ThrowLeft)
        {
            if (RB.transform.position == targetWayPoint.position && currentWayPoint != 0)
                    {
                        currentWayPoint--;
                        targetWayPoint = wayPointList[currentWayPoint];
                    }
            if (currentWayPoint == 0)
            {
                ThrowLeft = false;
            }
        }
        
    }
    public void SetBasemanAnimation(Animator Anim, string Variable, bool Throw)
    {
        //if (Throw)
        //{
        //    Anim.Play("LThrow");
        //}
        //if (!Throw)
        //{
        //    Anim.Play("Idle");
        //}
        Anim.SetBool(Variable, Throw);
    }
    public void TwoPlayer()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ThrowLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ThrowRight = true;
        }
    }
    public void SetBallPosition()
    {
        if(ThrowLeft == true && BallPosition == "Right")
        {
            BallPosition = "Left";
        }
        if (ThrowRight == true && BallPosition == "Left")
        {
            BallPosition = "Right";
        }
    }
    public void SetRunnerPosition()
    {
        if (RunnerPosition != "Center")
        {
            if (Runner.transform.position.x > L.transform.position.x && Runner.transform.position.x < R.transform.position.x)
            {
                RunnerLastPosition = RunnerPosition;
                RunnerPosition = "Center";
            }
        }
        if (RunnerPosition != "Right")
        {
            if (Runner.transform.position.x > R.transform.position.x)
            {
                RunnerLastPosition = RunnerPosition;
                RunnerPosition = "Right";
            }
        }
        if (RunnerPosition != "Left")
        {
            if (Runner.transform.position.x < L.transform.position.x)
            {
                RunnerLastPosition = RunnerPosition;
                RunnerPosition = "Left";
            }
        }

    }
    public void BallLeft()
    {
        if(BallPosition != "Left")
        {
            ThrowLeft = true;
        }
    }
    public void BallRight()
    {
        if (BallPosition != "Right")
        {
            ThrowRight = true;
        }
    }

    public void ScorePoint()
    {
        score = score + 1;
        if (txtScore.text != score.ToString())
        {
            txtScore.text = score.ToString();
            txtAstroScore.text = score.ToString();
        }
        scoredPoint = true;
    }
    public void SetRandomNumber()
    {
        rand = UnityEngine.Random.Range(1,3);
    }
    public void SpeedUp(int ExpectedScore, float currentSpeed, float nextSpeed)
    {
        if (score >= ExpectedScore && speed == currentSpeed && (currentWayPoint == 7 || currentWayPoint == 0))
        {
            speed = nextSpeed;
        }
    }
    public void Out()
    {
        PlayerPrefs.SetInt("RecentScore", score);
        SceneManager.LoadScene("GameOver");
    }
}
