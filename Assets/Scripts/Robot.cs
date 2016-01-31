using UnityEngine;
using System.Collections;

public class Robot : Enemy {

    float speed;
    Player player;

	// Use this for initialization
	void Start () {
        base.Start();
        speed = 0.05f;
        player = GameObject.Find("Player").GetComponent<Player>();
	}

    void move(string direction)
    {
        switch (direction)
        {
            case ("right"):
                transform.Translate(Vector2.right * speed);
                break;
            case ("left"):
                transform.Translate(Vector2.left * speed);
                break;
            case ("up"):
                transform.Translate(Vector2.up * speed);
                break;
            case ("down"):
                transform.Translate(Vector2.down * speed);
                break;
        }
    }

    void makeMove()
    {
        float xToPlayer = base.player.transform.position.x - transform.position.x;
        float yToPlayer = player.transform.position.y - transform.position.y;

        if (Mathf.Abs(xToPlayer) > Mathf.Abs(yToPlayer))
        {
            if (xToPlayer > 0)
            {
                move("right");
            }
            if (xToPlayer < 0)
            {
                move("left");
            }
        }
        else
        {
            if (yToPlayer > 0)
                move("up");
            if (yToPlayer < 0)
                move("down");
        }
    }

	
	// Update is called once per frame
	void Update () {
        if (player.isDetected())
        {
            makeMove();
        }
	}
}
