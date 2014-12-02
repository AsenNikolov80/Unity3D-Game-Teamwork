using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{
    public int speed = 12;
    private float timeToMoveBack = 0;
    public Transform[] points;

    // Use this for initialization
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position == points[currentIndex].position)
        //{
        //    currentIndex++;
        //}
        //if (currentIndex >= points.Length)
        //{
        //    currentIndex = 0;
        //}

        //transform.position = Vector3.MoveTowards(transform.position, points[currentIndex].position, Time.deltaTime * speed);
        transform.position = Vector3.MoveTowards(transform.position, points[1].position, Time.deltaTime * speed);
        
        if (transform.position == points[1].position && timeToMoveBack >= 3)
        {
            transform.position = points[0].position;
            timeToMoveBack = 0;
        }
        if (transform.position == points[1].position)
        {
            timeToMoveBack += Time.deltaTime;
        }
    }
}
