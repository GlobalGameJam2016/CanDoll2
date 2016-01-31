using UnityEngine;
using System.Collections;

public class Robot : Enemy{

    float speed;
    Player player;
    enum DIRECTION {RIGHT, LEFT, UP, DOWN};
    DIRECTION face;
    float minDistance;
    bool touching;

	// Use this for initialization
	void Start () {
        base.Start();
        speed = 0.25f;
        player = GameObject.Find("Player").GetComponent<Player>();
        face = DIRECTION.RIGHT;
        minDistance = 1f;
        touching = false;
	}
    /*
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
    */
    void moveRight()
    {
        transform.Translate(Vector2.right * speed);
    }
    void moveLeft()
    {
        transform.Translate(Vector2.left * speed);
    }
    void moveUp()
    {
        transform.Translate(Vector2.up * speed);
    }
    void moveDown()
    {
        transform.Translate(Vector2.down * speed);
    }

    void makeMove(float xToPlayer, float yToPlayer)
    {

        if (Mathf.Abs(xToPlayer) > Mathf.Abs(yToPlayer))
        {
            if (xToPlayer > 0)
            {
                face = DIRECTION.RIGHT;
                moveRight();
            }
            if (xToPlayer < 0)
            {
                face = DIRECTION.LEFT;
                moveLeft();
            }
        }
        else
        {
            if (yToPlayer > 0)
            {
                face = DIRECTION.UP;
                moveUp();
            }
            if (yToPlayer < 0)
            {
                face = DIRECTION.DOWN;
                moveDown();
            }
        }
    }

    void facePlayer(float xToPlayer, float yToPlayer) { 
          if (Mathf.Abs(xToPlayer) > Mathf.Abs(yToPlayer))
        {
            if (xToPlayer > 0)
            {
                face = DIRECTION.RIGHT;
            }
            if (xToPlayer < 0)
            {
                face = DIRECTION.LEFT;
            }
        }
        else
        {
            if (yToPlayer > 0)
            {
                face = DIRECTION.UP;
                moveUp();
            }
            if (yToPlayer < 0)
            {
                face = DIRECTION.DOWN;
                moveDown();
            }
        }
    }

	
	// Update is called once per frame
	void Update () {
        float x = transform.eulerAngles.x;
        float y = transform.eulerAngles.y;

        Vector3 distanceToPlayer = player.transform.position - transform.position;
        float xToPlayer = distanceToPlayer.x;
        float yToPlayer = distanceToPlayer.y;

        if (xToPlayer < minDistance && yToPlayer < minDistance)
        {
            touching = true;
        } 

        if (player.isDetected())
        {
            if (touching)
                facePlayer(xToPlayer, yToPlayer);
            else makeMove(xToPlayer, yToPlayer);
                makeMove(xToPlayer, yToPlayer);
            switch (face)
            {
                case(DIRECTION.RIGHT) :
                    transform.eulerAngles = new Vector3(x, y, 0);
                    break;
                case (DIRECTION.LEFT):
                    transform.eulerAngles = new Vector3(x, y, 90);
                    break;
                case (DIRECTION.UP):
                    transform.eulerAngles = new Vector3(x, y, 270);
                    break;
                case (DIRECTION.DOWN):
                    transform.eulerAngles = new Vector3(x, y, 270);
                    break;
            }
        }
	}
}
