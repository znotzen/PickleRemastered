using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerScript : MonoBehaviour {
    Rigidbody2D RB;
    SpriteRenderer SR;
    float Speed;
    float RightBasePosition = 5.5f;
    float LeftBasePosition = -5.5f;
    bool RunRight = true;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Speed = 5f;
    }
    void Update () {
        RB.velocity = transform.right * Speed;

        //Hit Right Base
        if (RB.transform.position.x > RightBasePosition && RunRight == true)
        {
            RunningR(false);
        }

        //Hit Left Base
        if (RB.transform.position.x < LeftBasePosition && RunRight == false)
        {
            RunningR(true);
        }


        //Run Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) && RunRight == true)
        {
            RunningR(false);
        }

        //Run Right
        if (Input.GetKeyDown(KeyCode.RightArrow) && RunRight == false)
        {
            RunningR(true);
        }

    }
    public void RunningR(bool RunR)
    {
        RunRight = RunR;
        Speed = -Speed;
        SR.flipX = (!RunR);
    }
}
