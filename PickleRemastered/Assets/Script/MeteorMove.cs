using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMove : MonoBehaviour {

    public Sprite[] MeteorObjects;

    Rigidbody2D RB;
    public float Speed = 1f;

    public int random;
    public SpriteRenderer SR;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        random = (Random.Range(1, 4) - 1);
        if (SR.sprite == null)
        {
            SR.sprite = MeteorObjects[random];
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        RB.velocity = new Vector2(-1,-1) * Speed;

        CloudSpeed("Astro_Field_1", 0.5f);
        CloudSpeed("Astro_Field_3", 3f);
        CloudSpeed("Astro_Field_2", 1f);

       //RB.transform.position = Vector3.MoveTowards(transform.position, MeteorStop.transform.position, Speed * Time.deltaTime);
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
