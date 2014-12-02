using UnityEngine;
using System.Collections;

public class MovingGround : MonoBehaviour
{

    public Transform[] points;
    private int currentIndex = 0;
    internal static int speed = 6;
    public GameObject canvas;
    private Canvas c1;

    // Use this for initialization
    void Start()
    {
        canvas = (GameObject)GameObject.Find("Canvas");
        c1 = (Canvas)canvas.GetComponent("Canvas");
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {

        if (c1.enabled == false)
        {
            if (transform.position == points[currentIndex].position)
            {
                currentIndex++;
            }

            if (currentIndex >= points.Length)
            {
                currentIndex = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, points[currentIndex].position, speed * Time.deltaTime);
        }
        else
        {
            Debug.Log(34523);
        }
    }
}
