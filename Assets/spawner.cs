using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject tilemapGameObject;
    public GameObject ball;
    public float spawnTime = 3f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnBall", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnBall()
    {
        var newBall = GameObject.Instantiate(ball, transform.position, transform.rotation);

        newBall.GetComponent<cazatoare>().tilemapGameObject = GameObject.Find("zapada");
    }

}

