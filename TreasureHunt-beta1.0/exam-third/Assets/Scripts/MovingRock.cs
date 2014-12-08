using UnityEngine;
using System.Collections;

public class MovingRock : MonoBehaviour
{
    private Car car;
    private MovingRock[] rocks;
    private GameObject[] array;
    private Vector3[] startPos;

    // Use this for initialization
    void Start()
    {
        array = GameObject.FindGameObjectsWithTag("MovingRock");
        rocks = new MovingRock[array.Length];
        //Debug.Log(rocks.Length);
        car = (Car)GameObject.Find("Car").GetComponent("Car");
        startPos = new Vector3[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            rocks[i] = (MovingRock)array[i].GetComponent<MovingRock>();
            startPos[i] = rocks[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (Vector3.Distance(car.transform.position, rocks[i].transform.position) < 30)
            {
                rocks[i].animation.Play();
            }
        }
        
    }

    internal void Die()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            //rocks[i] = (MovingRock)array[i].GetComponent("MovingRock");
            rocks[i].animation.Stop();
            rocks[i].transform.position = startPos[i];
        }
    }
}
