using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardManager : MonoBehaviour {

    public Rigidbody2D RB;
    float speed = 10f;
    public bool open = false;
    public bool close = false;

    public GameObject SettingsCanvas;
    public GameObject CharacterCanvas;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (open == true)
        {
            RB.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.06f, -1.15f, 0), speed * Time.deltaTime);
        }
        if (RB.transform.position == new Vector3(0.06f, -1.15f, 0) && open == true)
        {
            open = false;
        }

        if (close == true)
        {
            RB.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0.06f, -11.15f, 0), speed * Time.deltaTime);
        }
        if (RB.transform.position == new Vector3(0.06f, -11.15f, 0) && close == true)
        {
            close = false;
        }
    }
    public void OpenClipboardSettings()
    {
        SettingsCanvas.SetActive(true);
        CharacterCanvas.SetActive(false);
        open = true;
    }
    public void OpenClipboardCharacter()
    {
        SettingsCanvas.SetActive(false);
        CharacterCanvas.SetActive(true);
        open = true;
    }
    public void CloseClipboard()
    {
        close = true;
    }

}
