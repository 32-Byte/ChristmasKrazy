using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveBoxUp : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Move the box upward in the y-axis
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player1")
        {
            Debug.Log("Player 2 wins");
            SceneManager.LoadScene("p2 wins", LoadSceneMode.Single);

        }
        if (collision.gameObject.name == "Player2")
        {
            Debug.Log("Player 1 wins");
            SceneManager.LoadScene("p1 win", LoadSceneMode.Single);
        }
    }

}