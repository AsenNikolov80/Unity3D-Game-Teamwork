using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    private Vector3 input;
    private Vector3 startPos;
    private bool success;
    private int speed = 30;
    private bool gameOver;
    public GameObject canvas;
    private Canvas c1;

    // Use this for initialization
    void Start()
    {
        canvas = (GameObject)GameObject.Find("Canvas");
        c1 = (Canvas)canvas.GetComponent("Canvas");
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (c1.enabled == false)
            {
                input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                rigidbody.AddForce(input * speed);
                if ((rigidbody.velocity - new Vector3(100, 0, 100)).sqrMagnitude > 2)
                {
                    rigidbody.AddForce(input / speed);
                }
            }
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Water")
        {
            Die();
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "MovingGround")
        {
            if (input == Vector3.zero)
            {
                transform.position = Vector3.MoveTowards(transform.position, other.transform.position + new Vector3(0, 0.6f, 0), MovingGround.speed * Time.deltaTime * 2.8f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, other.transform.position + input * 2.5f, MovingGround.speed * Time.deltaTime * 1.6f);
            }
        }

        if (other.transform.tag == "Target")
        {
            success = true;
        }
    }

    private void Die()
    {
        transform.position = startPos;
        rigidbody.velocity = Vector3.zero;
    }

    void OnGUI()
    {
        if (success)
        {
            GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Success!\n\n YOU WIN THE GAME!");
            gameOver = true;
        }
    }
}
