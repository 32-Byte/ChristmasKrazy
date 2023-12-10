// OnKeyPress.cs

using UnityEngine;

public class OnKeypress1 : MonoBehaviour
{
    float arrow_speed = -0.005f;
    float snowball_speed = 90000;
    float arrow_position = 0;
    float arrow_radius = 5f;

    LineRenderer lineRenderer;
    GameObject player;

    public LineRenderer componentToHide;
    // public Transform test;

    float degrees = Mathf.PI / 180;

    public GameObject snowball;
    void Start()
    {
        componentToHide.enabled = false;


        player = GameObject.FindGameObjectWithTag("Player1");

        //arrow_radius += player.transform.localScale.x;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, player.transform.position + new Vector3(arrow_radius, 0, 0));
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) componentToHide.enabled = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            Vector3 startPos = lineRenderer.GetPosition(0);
            Vector3 endPos = lineRenderer.GetPosition(1);
            Vector3 middlePos = ((endPos + startPos) / 2);

            GameObject curr_snowball = Instantiate(snowball, startPos, Quaternion.identity);
            bulgare custom_snowball = curr_snowball.GetComponent<bulgare>();
            custom_snowball.CustomSetParent(gameObject);
            Vector2 throwVector = (endPos - startPos).normalized * snowball_speed;
            curr_snowball.GetComponent<Rigidbody2D>().AddForce(throwVector);
            


            Physics2D.IgnoreCollision(curr_snowball.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("barrier").GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(curr_snowball.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player1").GetComponent<Collider2D>());
            //Physics2D.IgnoreCollision(curr_snowball.GetComponent<Collider2D>(), curr_snowball.GetComponent<Collider2D>() );



            componentToHide.enabled = false;
        }

        arrow_position += arrow_speed;
        if (arrow_position > degrees * 70 || arrow_position < 0)
        {
            if (arrow_position < 0) arrow_position = 0; else arrow_position = 70 * degrees;
            arrow_speed *= -1;
        }

        lineRenderer.SetPosition(0, player.transform.position);
        //lineRenderer.SetPosition(1, player.transform.position /*+ new Vector3(0.5f, 0.5f, 0)*/);

        float newX = Mathf.Cos(arrow_position) * arrow_radius + player.transform.position.x;
        float newY = Mathf.Sin(arrow_position) * arrow_radius + player.transform.position.y;
        // Debug.Log(arrow_speed);
        // Debug.Log(arrow_position);

        // test.position = new Vector3(newX , newY , 0);
        lineRenderer.SetPosition(1, new Vector3(newX, newY, 0));
    }
}