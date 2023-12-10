using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WINNER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player1")
        {
            Debug.Log("Player1 wins");
            SceneManager.LoadScene("p1 win", LoadSceneMode.Single);

        }
        if (collision.gameObject.name == "Player2")
        {
            SceneManager.LoadScene("p2 wins", LoadSceneMode.Single);

            Debug.Log("Player2 wins");
        }
    }
}
