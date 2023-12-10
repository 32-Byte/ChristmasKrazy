using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class bulgare1 : MonoBehaviour
{

    public GameObject tilemapGameObject;
    //bool deleting = false;
    Tilemap tilemap;
    public RuleTile zap;
    public GameObject player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool hasHitPlayer;

    void Start()
    {
        hasHitPlayer = false;
        var rb = GetComponent<Rigidbody2D>();
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //bool explode = false;
        Vector3 hitPosition = Vector3.zero;
        if (collision.gameObject.tag.Contains("Player"))
        {
            hasHitPlayer = true;
            Debug.Log("HIT PLAYER!");

            Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>());

            //Destroy(gameObject);
            
            return;
        }

        if (tilemapGameObject == collision.gameObject && hasHitPlayer) { Destroy(gameObject); return; }
        if (tilemapGameObject == collision.gameObject)
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x + 0.1f * hit.normal.x;
                hitPosition.y = hit.point.y + 0.1f * hit.normal.y;

                if ((-14f<hitPosition.x && hitPosition.x < -5f) || (13f>hitPosition.x && hitPosition.x > 4f))
                {
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), zap);
                    //Debug.Log("sAAAAAAAAAAAAAA");
                }
            }
            //deleting = true;
            Destroy(this.gameObject);
        }
        //if(collision.gameObject)



        //Vector2 actualposition = GameObject.Find("Square").transform.position;
        //GameObject.Find("Square").transform.position = new Vector2(actualposition.x, actualposition.y + 0.7f);


    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
