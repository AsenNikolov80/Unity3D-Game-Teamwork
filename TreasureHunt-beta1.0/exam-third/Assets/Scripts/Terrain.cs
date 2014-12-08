using UnityEngine;
using System.Collections;

public class Terrain : MonoBehaviour
{
    public static Vector3 startPosTerrain = new Vector3(213.8f, 1.4f, 0);
    public bool isEnd;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnd)
        {
            transform.Translate(new Vector3(-0.3f, 0, 0));
        }

    }

    public void Die()
    {
        transform.position = startPosTerrain;
    }
}
