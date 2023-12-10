// P1_snowball.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1_snowball : MonoBehaviour
{
    Vector2 throwVector;
    Rigidbody2D _rb;

    string[] colliders = { "Ground", /*"Player1",*/ "Player2", "Wall" };

    void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        // Renderer renderer = this.GetComponent<Renderer>();
        // renderer.transform.localScale = new Vector3(5,5,1);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}