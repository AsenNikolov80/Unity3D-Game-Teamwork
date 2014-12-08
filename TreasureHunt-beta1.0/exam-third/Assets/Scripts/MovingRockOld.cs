using UnityEngine;
using System.Collections;

public class MovingRockOld : MonoBehaviour
{

    public GameObject[] points;
    private Vector3[] startPos;
    private GameObject[] array;
    private MovingRock[] rocks;
    private Car car;

    // Use this for initialization
    void Start()
    {
        array = GameObject.FindGameObjectsWithTag("MovingRock");
        car = (Car)GameObject.Find("Car").GetComponent("Car");
        points = GameObject.FindGameObjectsWithTag("Point");
        startPos = new Vector3[array.Length];
        rocks = new MovingRock[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            rocks[i] = (MovingRock)array[i].GetComponent("MovingRock");
            startPos[i] = rocks[i].transform.position;
            rocks[i].transform.position = points[i * 2].transform.position;
        }
        for (int i = 0; i < startPos.Length; i++)
        {
            Debug.Log(startPos[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rocks.Length; i++)
        {
            if (Vector3.Distance(car.transform.position, rocks[i].transform.position) < 50)
            {
                rocks[i].transform.position =
                        Vector3.MoveTowards(rocks[i].transform.position,
                        points[i * 2 + 1].transform.position, 2.5f * Time.deltaTime);
            }
        }
    }

    internal void Die()
    {
        for (int i = 0; i < startPos.Length; i++)
        {
            rocks[i].transform.position = startPos[i];
        }
    }
}
