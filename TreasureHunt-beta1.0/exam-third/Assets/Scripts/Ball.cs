using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Car car;
    private Vector3[] startPos;
    private Ball[] movingBalls;
    private bool[] isNear;

    // Use this for initialization
    void Start()
    {
        var arrayOfBalls = GameObject.FindGameObjectsWithTag("Ball");
        movingBalls = new Ball[arrayOfBalls.Length];
        startPos = new Vector3[arrayOfBalls.Length];
        isNear = new bool[arrayOfBalls.Length];

        for (int i = 0; i < arrayOfBalls.Length; i++)
        {
            movingBalls[i] = (Ball)arrayOfBalls[i].GetComponent("Ball");
            startPos[i] = movingBalls[i].transform.position;
        }

        car = (Car)GameObject.Find("Car").GetComponent("Car");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < movingBalls.Length; i++)
        {
            if (!isNear[i])
            {
                if (Vector3.Distance(movingBalls[i].transform.position, car.transform.position) < 45)
                {
                    isNear[i] = true;
                    StartMoving();
                }
            }
        }
    }

    private void StartMoving()
    {
        rigidbody.AddForce(new Vector3(-1000, 0, 420));
    }

    internal void Die()
    {
        for (int i = 0; i < movingBalls.Length; i++)
        {
            movingBalls[i].transform.position = startPos[i];
            movingBalls[i].rigidbody.velocity = Vector3.zero;
            movingBalls[i].rigidbody.velocity = new Vector3(4.1f, 0, 0);
        }
        for (int i = 0; i < isNear.Length; i++)
        {
            isNear[i] = false;
        }
    }
}
