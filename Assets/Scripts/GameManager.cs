using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Time to wait to start a level (display black screen)
	public float levelStartDelay = 1f;
    public static GameManager instance = null;
    private int level = 1;
    public Player player;
    public List<Enemy> enemies; 

	// Display level
	private Text levelText;
	// Use this to show or hide level loading screen
	private GameObject levelImage;

	// Prevent player from moving during setup
	private bool doingSetup;

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
		levelImage.SetActive (false);
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
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Night " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
	}

	// Update is called once per frame
	void Update () 
	{
		if (doingSetup)
			return;
	
	}
}
