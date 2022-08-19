using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour {

    public Sprite[] Balls;
    public string[] Runners;

    public GameObject NormalBackground;
    public GameObject AstroBackground;
    public GameObject AstroStars;

    public Rigidbody2D AstroScore;

    public SpriteRenderer PlayingBall;
    public Animator PlayingRunner;

    public Transform bottomWayPoint;
    public Transform topWayPoint;
    float speed = 0.2f;
    public bool ScoreUp = false;
    public bool ScoreDown = true;
    public bool Astro = false;


    // Use this for initialization
    void Start () {
        NormalBackground.SetActive(true);
        AstroBackground.SetActive(false);

        PlayingBall.sprite = Balls[PlayerPrefs.GetInt("PlayingBall")];
        PlayingRunner.Play(Runners[PlayerPrefs.GetInt("PlayingRunner")]);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerPrefs.GetInt("PlayingField") == 1)
        {
            //If AstroField
            if (Astro == false)
            {
                NormalBackground.SetActive(false);
                AstroBackground.SetActive(true);
                Astro = true;
            }
            if (ScoreDown)
            {
                AstroScore.transform.position = Vector3.MoveTowards(AstroScore.transform.position, bottomWayPoint.position, speed * Time.deltaTime);
            }
            if (ScoreDown && AstroScore.transform.position == bottomWayPoint.position)
            {
                ScoreDown = false;
                ScoreUp = true;
            }

            if (ScoreUp)
            {
                AstroScore.transform.position = Vector3.MoveTowards(AstroScore.transform.position, topWayPoint.position, speed * Time.deltaTime);
            }
            if (ScoreUp && AstroScore.transform.position == topWayPoint.position)
            {
                ScoreUp = false;
                ScoreDown = true;
            }
        }
    }
}
