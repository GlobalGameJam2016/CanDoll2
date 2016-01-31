using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource efxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;


	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			// Game is over
			Destroy (gameObject);
		// Background music keeps playing in between levels
		DontDestroyOnLoad (gameObject);

	}
	// Plays a single audio clip 
	// can be called from other scripts 
	// clip = sound effects or music loop
	public void PlaySingle(AudioClip clip){
		efxSource.clip = clip;
		efxSource.Play ();
	}

	// requires array of audio clips

	public void RandomizeSfx(params AudioClip [] clips){
		// chooses random clip to play from audio clip array
		int randomIndex = Random.Range (0, clips.Length);
		// creates variation of pitch in music
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		// sets the sound to random pitch and clip
		efxSource.pitch = randomPitch;
		efxSource.clip = clips [randomIndex];
		efxSource.Play ();
	}
}