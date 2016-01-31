using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Time to wait to start a level (display black screen)
	public float levelStartDelay = 1f;
    public static GameManager instance = null;
	public int level = 1;
	public bool game;
    public Player player;
    public List<Enemy> enemies; 
	public GameObject textPanel;
	public GameObject[] items;
	public Transform shithole;
	public Vector3[] originalPosition;

	// Display level
	//private Text levelText;
	// Use this to show or hide level loading screen
	//private GameObject levelImage;

	// Prevent player from moving during setup
	public bool doingSetup;

	private GameManager(){
	}

	// Use this for initialization
	void Awake () {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        InitGame();

        player = GameObject.Find("Player").GetComponentInChildren<Player>();
        enemies = new List<Enemy>();
	}

	private void HideLevelImage()
	{
		//levelImage.SetActive (false);
		//textPanel.SetActive (true);
		doingSetup = false;
	}

	public void GameOver()
	{
		Debug.Log ("GAME OVER");

		enabled = false;
	}

	private void OnLevelWasLoaded (int index)
	{
		level++;
		InitGame ();
	}

    void InitGame()
	{
		doingSetup = true;
		textPanel.SetActive (true);
		for (int i = 1; i < items.Length; i++) {
			originalPosition [i] = items [i].transform.position;
			items [i].transform.position = shithole.position;
		}
		//textPanel = GameObject.Find ("Panel");
		//levelImage = GameObject.Find ("LevelImage");
		//levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		//levelText.text = "Night " + level;
		//textPanel.SetActive (false);
		//levelImage.SetActive (true);
		//Invoke ("HideLevelImage", levelStartDelay);
	}

	// Update is called once per frame
	void Update () 
	{
		if (doingSetup) {
			player.candleLife = 1000000;
			return;
		}
	
	}
}
