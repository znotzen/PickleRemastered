using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour {

    public SpriteRenderer Field;

    public Sprite OrigField;
    public Sprite AstroField;

    public Text txtHighScore;

    public GameObject NewHS;


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("PlayingField") == 1)
        {
            Field.sprite = AstroField;
        }
        else
        {
            Field.sprite = OrigField;
        }
        txtHighScore.text = PlayerPrefs.GetInt("RecentScore").ToString();
        if (PlayerPrefs.GetInt("RecentScore") == PlayerPrefs.GetInt("HighScore"))
        {
            NewHS.SetActive(true);
        }
        else
        {
            NewHS.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void BtnYes()
    {
        SceneManager.LoadScene("Game");
    }
    public void BtnNo()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
