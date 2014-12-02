using UnityEngine;
using System.Collections;

public class CanvasLogic : MonoBehaviour
{
    private Canvas canvas;
    // Use this for initialization
    void Start()
    {
        canvas = (Canvas)gameObject.GetComponent("Canvas");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        canvas.enabled = false;
    }
}
