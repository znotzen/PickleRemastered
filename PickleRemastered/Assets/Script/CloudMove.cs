using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

    public Sprite[] CloudObjects;

    Rigidbody2D RB;
    public float Speed = 0.1f;

    public int random;
    public SpriteRenderer SR;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        random = (Random.Range(1, 4) - 1);
        if (SR.sprite == null)
        {
            SR.sprite = CloudObjects[random];
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        RB.velocity = -transform.right * Speed;

        CloudSpeed("Pickle_Running_Bases_32", 0.6f);
        CloudSpeed("Pickle_Running_Bases_31", 0.8f);
        CloudSpeed("Pickle_Running_Bases_29", 0.5f);
        CloudSpeed("Pickle_Running_Bases_30", 1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    public void CloudSpeed(string SpriteName, float speed)
    {
        if (SR.sprite.name == SpriteName && Speed != speed)
        {
            Speed = speed;
        }
    }
}
