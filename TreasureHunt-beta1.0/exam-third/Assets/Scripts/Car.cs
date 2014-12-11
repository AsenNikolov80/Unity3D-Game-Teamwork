using UnityEngine;
using System.Collections;
using System;

public class Car : MonoBehaviour
{
    private float speed = 4f;
    private Vector3 startPos = new Vector3(-28, 3, 0);
    private Terrain terrain;
    private MovingRock[] movingRocks;
    private AudioSource carCrash;

    //private Ball[] movingBalls;

    // Use this for initialization
    void Start()
    {
        var arrayOfMovingRocks = GameObject.FindGameObjectsWithTag("MovingRock");
        movingRocks = new MovingRock[arrayOfMovingRocks.Length];
        for (int i = 0; i < arrayOfMovingRocks.Length; i++)
        {
            movingRocks[i] = (MovingRock)arrayOfMovingRocks[i].GetComponent("MovingRock");
        }
        Screen.showCursor = false;
        carCrash = (AudioSource)GameObject.Find("Car-Crash").GetComponent<AudioSource>();
        //var arrayOfMovingBalls = GameObject.FindGameObjectsWithTag("Ball");
        //movingBalls = new Ball[arrayOfMovingBalls.Length];
        //for (int i = 0; i < arrayOfMovingBalls.Length; i++)
        //{
        //    movingBalls[i] = (Ball)arrayOfMovingBalls[i].GetComponent("Ball");
        //}

        terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        var input = new Vector3(Input.GetAxis("Horizontal") / speed, Input.GetAxis("Vertical") / speed, 0);
        transform.Translate(input);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy"
            || other.transform.tag == "MovingRock"
            || other.transform.tag == "Ball")
        {
            carCrash.Play();
            Die();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "FinishLine")
        {
            DoSomething();
        }
    }

    private void ShowEnd()
    {
        terrain.isEnd = true;
        Screen.showCursor = true;
    }
    private void DoSomething()
    {
        Invoke("ShowEnd", 1.4f);
    }

    public void Die()
    {
        terrain.Die();
        transform.position = startPos;
        for (int i = 0; i < movingRocks.Length; i++)
        {
            movingRocks[i].Die();
        }
        //for (int i = 0; i < movingBalls.Length; i++)
        //{
        //    movingBalls[i].Die();
        //}
    }
    public void OnGUI()
    {
        if (terrain.isEnd)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200), "YOU WIN\nClick to continue!"))
            {
                Application.LoadLevel("exam3-car");
            }
        }
    }
}
