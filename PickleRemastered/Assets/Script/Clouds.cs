using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public GameObject cloud;
    public Transform CloudStart;

    float rand;

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("PlayingField") == 0)
        {
            InvokeRepeating("RandomNumber", 0.01f, 10f);
            InvokeRepeating("Spawn", 0.1f, 10f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn()
    {
        Instantiate(cloud, CloudStart.transform.position + new Vector3(0,rand,0), CloudStart.transform.rotation);
    }
    public void RandomNumber()
    {
        rand = Random.Range(0f, 2.6f);
    }
}
