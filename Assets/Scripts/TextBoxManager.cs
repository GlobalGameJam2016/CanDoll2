using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public GameManager gameManager;
	public Text theText;

	public int currentLine;
	public int endAtLine;

	public TextAsset textFile;
	public string[] textLines;

	// Use this for initialization
	void Start() {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;

		}
	}

	// Update is called once per frame
		void Update() {
			
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (currentLine > endAtLine) {
				//textBox.SetActive (false);
				textBox.SetActive(false);

				GameManager.instance.doingSetup = false;
				return;
			}
			theText.text = textLines [currentLine];
			currentLine++;
		}


		//return;
//		if 
//			(Input.GetKeyDown (KeyCode.Return)) { 
//			
//				currentLine++;
//				//textBox.SetActive (false);
//
//		}
//
//		if (currentLine > endAtLine)
//		if (currentLine <= endAtLine) {
//			textBox.SetActive (false);
//			if (Input.GetKeyDown (KeyCode.Return)) {
//				currentLine++;
//			}
//		}
	}
}