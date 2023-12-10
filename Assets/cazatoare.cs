using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class cazatoare : MonoBehaviour
{

    public GameObject tilemapGameObject;
    //bool deleting = false;
    Tilemap tilemap;
    public RuleTile zap;
    //public GameObject player1;
   // public GameObject player2;

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        bool explode = false;
        Vector3 hitPosition = Vector3.zero;
        if (tilemapGameObject == collision.gameObject)
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {

                hitPosition.x = hit.point.x + 0.1f * hit.normal.x;
                hitPosition.y = hit.point.y + 0.1f * hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), zap);
                //Debug.Log("sAAAAAAAAAAAAAA");

            }

        }
        //deleting = true;
        Destroy(this.gameObject);

        Vector2 actualposition1 = GameObject.Find("Player1").transform.position;
        GameObject.Find("Square").transform.position = new Vector2(actualposition1.x, actualposition1.y + 0.7f);
        Vector2 actualposition2 = GameObject.Find("Player2").transform.position;
        GameObject.Find("Square").transform.position = new Vector2(actualposition2.x, actualposition2.y + 0.7f);

    }

    void OnCollisionExit2D(Collision2D collision)
    {

    }

}
