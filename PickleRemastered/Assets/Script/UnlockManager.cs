using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour {

    public Text txtHighScore;
    public Text txtRecentScore;
    public Text txtScoreLocked;
    public GameObject ScoreLocked;
    public string selecting = "Field";

    public SpriteRenderer FieldImage;
    public GameObject FieldImageGO;

    public SpriteRenderer BallImage;
    public GameObject BallImageGO;

    public SpriteRenderer RunnerImage;
    public GameObject RunnerImageGO;

    public SpriteRenderer BasemenImage;
    public GameObject BasemenImageGO;

    public GameObject Lock;
    public GameObject Check;

    public Sprite[] Fields;
    public int[] FieldScores;
    public int selectedField;

    public Sprite[] Balls;
    public int[] BallScores;
    public int selectedBall;

    public Sprite[] Runners;
    public int[] RunnerScores;
    public int selectedRunner;

    public Sprite[] Basemen;
    public int[] BasemenScores;
    public int selectedBasemen;

    public Button BField;
    public Button BBall;
    public Button BRunner;
    public Button BBasemen;



	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            PlayerPrefs.SetInt("PlayingField", 0);
            PlayerPrefs.SetInt("PlayingBall", 0);
            PlayerPrefs.SetInt("PlayingRunner", 0);
            PlayerPrefs.SetInt("PlayingBasemen", 0);
        }

        txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        txtRecentScore.text = PlayerPrefs.GetInt("RecentScore").ToString();
        selectedField = PlayerPrefs.GetInt("SelectedField");
        FieldImage.sprite = Fields[selectedField];
        BtnField();
    }
	
	// Update is called once per frame
	void Update () {

        //Reset High Score
        if (Input.GetKeyDown(KeyCode.F12))
        {
            PlayerPrefs.SetInt("HighScore", 0);
            txtHighScore.text = PlayerPrefs.GetInt("HighScore").ToString();

            PlayerPrefs.SetInt("PlayingField", 0);
            PlayerPrefs.SetInt("PlayingBall", 0);
            PlayerPrefs.SetInt("PlayingRunner", 0);
            PlayerPrefs.SetInt("PlayingBasemen", 0);
        }

        Locked(PlayerPrefs.GetInt("HighScore"), FieldScores, selectedField, FieldImage, "Field");
        Unlocked(PlayerPrefs.GetInt("HighScore"), FieldScores, selectedField, FieldImage, "Field", "PlayingField");

        Locked(PlayerPrefs.GetInt("HighScore"), BallScores, selectedBall, BallImage, "Ball");
        Unlocked(PlayerPrefs.GetInt("HighScore"), BallScores, selectedBall, BallImage, "Ball", "PlayingBall");

        Locked(PlayerPrefs.GetInt("HighScore"), RunnerScores, selectedRunner, RunnerImage, "Runner");
        Unlocked(PlayerPrefs.GetInt("HighScore"), RunnerScores, selectedRunner, RunnerImage, "Runner", "PlayingRunner");

        Locked(PlayerPrefs.GetInt("HighScore"), BasemenScores, selectedBasemen, BasemenImage, "Basemen");
        Unlocked(PlayerPrefs.GetInt("HighScore"), BasemenScores, selectedBasemen, BasemenImage, "Basemen", "PlayingBasemen");
    }

    public void rightArrow()
    {
        if (selecting == "Field")
        {
            if (selectedField < (Fields.Length - 1))
            {
                selectedField = selectedField + 1;
                FieldImage.sprite = Fields[selectedField];
            }
        }else if (selecting == "Ball")
        {
            if (selectedBall < (Balls.Length - 1))
            {
                selectedBall = selectedBall + 1;
                BallImage.sprite = Balls[selectedBall];
            }
        }
        else if (selecting == "Runner")
        {
            if (selectedRunner < (Runners.Length - 1))
            {
                selectedRunner = selectedRunner + 1;
                RunnerImage.sprite = Runners[selectedRunner];
            }
        }
        else if (selecting == "Basemen")
        {
            if (selectedBasemen < (Basemen.Length - 1))
            {
                selectedBasemen = selectedBasemen + 1;
                BasemenImage.sprite = Basemen[selectedBasemen];
            }
        }

    }
    public void leftArrow()
    {
        if (selecting == "Field")
        {
            if (selectedField > 0)
            {
                selectedField = selectedField - 1;
                FieldImage.sprite = Fields[selectedField];
            }
        }else if (selecting == "Runner")
        {
            if (selectedRunner > 0)
            {
                selectedRunner = selectedRunner - 1;
                RunnerImage.sprite = Runners[selectedRunner];
            }
        }
        else if (selecting == "Ball")
        {
            if (selectedBall > 0)
            {
                selectedBall = selectedBall - 1;
                BallImage.sprite = Balls[selectedBall];
            }
        }
        else if (selecting == "Basemen")
        {
            if (selectedBasemen > 0)
            {
                selectedBasemen = selectedBasemen - 1;
                BasemenImage.sprite = Basemen[selectedBasemen];
            }
        }
    }
    public void BtnApply()
    {
        if (Lock.activeInHierarchy == false)
        {
            if (selecting == "Field")
            {
                PlayerPrefs.SetInt("PlayingField", selectedField);
            }
            else if (selecting == "Runner")
            {
                PlayerPrefs.SetInt("PlayingRunner", selectedRunner);
            }
            else if (selecting == "Ball")
            {
                PlayerPrefs.SetInt("PlayingBall", selectedBall);
            }
            else if (selecting == "Basemen")
            {
                PlayerPrefs.SetInt("PlayingBasemen", selectedBasemen);
            }
        }
    }
    public void BtnField()
    {
        selecting = "Field";
        BField.image.color = Color.black;
        BBall.image.color = Color.white;
        BRunner.image.color = Color.white;
        BBasemen.image.color = Color.white;

        FieldImageGO.SetActive(true);
        BallImageGO.SetActive(false);
        RunnerImageGO.SetActive(false);
        BasemenImageGO.SetActive(false);


    }
    public void BtnBall()
    {
        selecting = "Ball";
        BField.image.color = Color.white;
        BBall.image.color = Color.black;
        BRunner.image.color = Color.white;
        BBasemen.image.color = Color.white;

        FieldImageGO.SetActive(false);
        BallImageGO.SetActive(true);
        RunnerImageGO.SetActive(false);
        BasemenImageGO.SetActive(false);
    }
    public void BtnRunner()
    {
        selecting = "Runner";
        BField.image.color = Color.white;
        BBall.image.color = Color.white;
        BRunner.image.color = Color.black;
        BBasemen.image.color = Color.white;

        FieldImageGO.SetActive(false);
        BallImageGO.SetActive(false);
        RunnerImageGO.SetActive(true);
        BasemenImageGO.SetActive(false);
    }
    public void BtnBasemen()
    {
        selecting = "Basemen";
        BField.image.color = Color.white;
        BBall.image.color = Color.white;
        BRunner.image.color = Color.white;
        BBasemen.image.color = Color.black;

        FieldImageGO.SetActive(false);
        BallImageGO.SetActive(false);
        RunnerImageGO.SetActive(false);
        BasemenImageGO.SetActive(true);
    }

    public void Locked(int HS, int[] scores, int selected, SpriteRenderer image, string choosing)
    {
        if (selecting == choosing)
        {
            if (HS < scores[selected])
            {
                //Locked
                Lock.SetActive(true);
                txtScoreLocked.text = scores[selected].ToString();
                Color myColor = new Color();
                ColorUtility.TryParseHtmlString("#313131FF", out myColor);
                image.color = myColor;
                ScoreLocked.SetActive(true);
            }
        }
    }
    public void Unlocked(int HS, int[] scores, int selected, SpriteRenderer image, string choosing, string playingPref)
    {
        if (selecting == choosing)
        {
            if (HS >= scores[selected])
            {
                //Unlocked
                Lock.SetActive(false);
                Color myColor = new Color();
                ColorUtility.TryParseHtmlString("#FFFFFFFF", out myColor);
                image.color = myColor;
                ScoreLocked.SetActive(false);
            }
            if (PlayerPrefs.GetInt(playingPref) == selected)
            {
                Check.SetActive(true);
            }
            else
            {
                Check.SetActive(false);
            }
        }
    }
}
