using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterMovement : MonoBehaviour {

    public bool LetterUp;
    public bool LetterDown;
    float speed = 1f;

    public Rigidbody2D N;

    public float timeDelay;

    public string[] Letters;

    // Use this for initialization
    void Start () {
        N = GetComponent<Rigidbody2D>();

        for (int i = 0; i <= Letters.Length-1; i++)
        {
            SetTimeDelay(i);
        }

        InvokeRepeating("SetLetterUpTrue", timeDelay, 5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (LetterUp)
        {
            N.transform.position = Vector3.MoveTowards(N.transform.position, N.transform.position + new Vector3(0, 0.2f, 0), speed * Time.deltaTime);
        }
        if (LetterUp && N.transform.position.y > 2.6f)
        {
            LetterUp = false;
            LetterDown = true;
        }
        if (LetterDown)
        {
            N.transform.position = Vector3.MoveTowards(N.transform.position, N.transform.position + new Vector3(0, -0.2f, 0), speed * Time.deltaTime);
        }
        if (LetterDown && N.transform.position.y <= 2.35f)
        {
            LetterDown = false;
            LetterUp = false;
        }

        
    }
    public void SetLetterUpTrue()
    {
        LetterUp = true;
    }
    public void SetTimeDelay(int x)
    {
        if (this.name == Letters[x])
        {
            timeDelay = 0.1f + (0.1f * x);
        }
    }
}
