using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	public void restart_game()
	{
		display_text ("");
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public static void display_text(string text)
	{
		GameObject gameTextObj = GameObject.Find ("GameText");
		Text gameText = gameTextObj.GetComponent<Text> ();
		gameText.text = text;
	}

	public void credits() {
		display_text ("");
		Application.LoadLevel("credit");
	}
	public void tutorial() {
		display_text ("");
		Application.LoadLevel("tut01");
	}
	public void tut2() {
		display_text ("");
		Application.LoadLevel("tut02");
	}
	public void tut3() {
		display_text ("");
		Application.LoadLevel("tut03");
	}
	public void tut4() {
		display_text ("");
		Application.LoadLevel("tut04");
	}
	public void tut5() {
		display_text ("");
		Application.LoadLevel("tut05");
	}

	public void start_scene()
	{
		display_text ("Attack of the Vikings");
		Time.timeScale = 0;

		Application.LoadLevel ("main");
		;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
