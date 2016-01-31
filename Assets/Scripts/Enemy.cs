using UnityEngine;
using System.Collections;

public class Enemy : Actor
{

    int viewDist;
    int viewAngle;
    Vector3 lookat;
    string objectName;
    GameObject enemyObject;
    protected GameObject player;
    protected DetectCone detectCone;
    protected ViewCone viewCone;
    BoxCollider2D detectBox;
    BoxCollider2D viewBox;


    // Use this for initialization
    void Start()
    {
        objectName = "Enemy";
        player = GameObject.Find("Player");
        enemyObject = GameObject.Find("Enemy");
        detectCone = GameObject.Find("Enemy").GetComponentInChildren<DetectCone>();
        viewCone = GameObject.Find("Enemy").GetComponentInChildren<ViewCone>();
        detectBox = detectCone.GetComponent<BoxCollider2D>();
        viewBox = detectCone.GetComponent<BoxCollider2D>();

        //    PolygonCollider2D detectCone = enemyObject.GetComponentInChildren<DetectCone>().PolygonCollider2D;  

        //    viewAngle = detectCone.GetComponent<Transform>().rotate();
    }

    void facePlayer()
    {
        float yStandard = transform.position.y;
        Vector3 lookat = player.transform.position;
        Vector3 horizontal = new Vector3(player.transform.position.x, yStandard, 0);

        float adj = lookat.x - transform.position.x;
        float opp = transform.position.y - lookat.y;
        float angle = Mathf.Atan(opp / adj);
        transform.Rotate(new Vector3(0, 0, -angle));

    }



    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.player.isDetected())
        {
            //facePlayer(); 

        }
    }

}
