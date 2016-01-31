using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Actor {
	public int candleLife;
	public bool hasShoe;
	public bool hasGlasses;
	public bool hasHair;
	public bool hasBlood;
	public bool hasButton;

    private bool detected;
	public int hiddenRate;
	public int detectedRate;
	public Text candleText;
    public Text detectedText;
	public float speed;
	public int dogDamage;
	Animator anum;

	// Dirty little hack...
	public GameObject gameOverImage;
	public Text gameOverText;

	// Use this for initialization
	protected override void Start () {
        candleLife = 1000000;
        detected = false;
        base.speed = 8;
        base.Start();

		candleText.text = "Candlelight: " + candleLife;
//        detectedText.text = "Detected: " + detected;

		// Hack pt 2
		gameOverImage = GameObject.Find ("GameOverImage");
		gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();
		gameOverImage.SetActive (false);

		//gets animator object
		anum = GetComponent<Animator>();
		anum.SetInteger ("Direction", 0);
	}

    public int getCandleLife() 
	{
        return candleLife;
    }

    public void detect() 
	{
        detected = true;

    }

    public void hide()
    {
        detected = false;
    }

    public bool isDetected() {
        return detected;
    }

	// Decrements the candle life once every frame depending
	// on the hidden state
	private void TickCandle()
	{
		if (detected) {
			candleLife -= detectedRate;
		} else {
			candleLife -= hiddenRate;
		}
	}

	private void GetDamage()
	{
		candleLife -= dogDamage;
	}

	private void Restart()
	{
		if (Input.GetKey (KeyCode.R)) {
			Application.LoadLevel (0);
		}
	}
	private void Death(){
		gameOverText.text = "Game Over! Press R to restart";
		gameOverImage.SetActive (true);
		Invoke ("Restart", 0f);
	}

	void OnCollisionEnter2D (Collision2D obj)
	{
		if (obj.gameObject.tag == "Enemy") {
			GetDamage ();
		}
	}

	// Update is called once per frame
	void Update () {
		TickCandle ();
		candleText.text = "Candlelight: " + Mathf.Round(candleLife/10000) + "%";
//        detectedText.text = "Detected: " + detected;
//        int horizontal = 0;
//        int vertical = 0;
//
//        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
//        vertical = (int)(Input.GetAxisRaw("Vertical"));
//
//        if (horizontal != 0 || vertical != 0) {
//            base.Move(horizontal, vertical);
//        }
//
		if (candleLife <=0) Death();
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate (Vector2.right * speed);
			anum.SetInteger ("Direction", 3);

		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate (Vector2.left * speed);
			anum.SetInteger ("Direction", 1);
		}
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector2.up * speed);
			anum.SetInteger ("Direction", 2);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate (Vector2.down * speed);
			anum.SetInteger ("Direction", 0);
		}
	}
}
