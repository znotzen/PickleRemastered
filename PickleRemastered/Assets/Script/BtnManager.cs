using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {

    public SpriteRenderer playerNum;
    public Sprite one;
    public Sprite two;
    public bool OnePlayer;

    public AudioSource MusicAudioSource;
    public Slider MusicSlider;

	// Use this for initialization
	void Start () {
        playerNum.sprite = one;
        OnePlayer = true;
        PlayerPrefs.SetInt("PlayerNum", 1);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            OnePlayer = !OnePlayer;
        }
        if(OnePlayer == true && playerNum.sprite != one)
        {
            playerNum.sprite = one;
            PlayerPrefs.SetInt("PlayerNum", 1);
        }
        if (OnePlayer == false && playerNum.sprite != two)
        {
            playerNum.sprite = two;
            PlayerPrefs.SetInt("PlayerNum", 2);
        }

        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        MusicAudioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void BtnPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
