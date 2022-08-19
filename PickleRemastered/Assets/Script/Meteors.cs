using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors : MonoBehaviour {

    public GameObject Meteor;
    public Transform MeteorStart;

    float rand;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("PlayingField") == 1)
        {
            InvokeRepeating("RandomNumber", 0.01f, 4f);
            InvokeRepeating("Spawn", 0.1f, 4f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        Instantiate(Meteor, MeteorStart.transform.position + new Vector3(rand, 0, 0), MeteorStart.transform.rotation);
    }
    public void RandomNumber()
    {
        rand = Random.Range(0f, 13f);
    }
}
