using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stemScript : MonoBehaviour {
	public static float life;
	public static float lifeInit = 20f;
	GameObject lifeBar;
	Image lifeBarImage;
	GameObject lifePercent;
	Text lifePercentText;
	// Use this for initialization
	void Start () {
		life = lifeInit;
		getLifePercent ();
		lifeBar = GameObject.Find ("PlantLifeBar");
		lifeBarImage = lifeBar.GetComponent<Image>();
		lifePercent = GameObject.Find ("PlantLifePercentText");
		lifePercentText = lifePercent.GetComponent<Text> ();
	}
	public static float getLifePercent()
	{
		float ret = (life / lifeInit);
		Debug.Log ("Life percent: " + ret + ", life = " + life + ", total = " + lifeInit);
		return ret;
	}
	public static string getLifePercentText()
	{
		return "" + getLifePercent () * 100 + "%";
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("Colliding");
		if (col.gameObject.tag == "minion") {
			Debug.Log("dwarf is eating me");
			transform.Translate(Vector2.up * -1 * 0.2f);
			GetComponent<AudioSource>().Play(); // chopping
			life--;
			lifeBarImage.fillAmount = getLifePercent();
			lifePercentText.text = getLifePercentText();
		}
	}
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			Debug.Log("Starting over");
			main.gameOver();
		}
//		if (Input.GetKeyDown (KeyCode.W)) 
//		{
//			transform.Translate(Vector2.up * 1 * 0.2f);
//		}
//		if (Input.GetKeyDown (KeyCode.S)) 
//		{
//			transform.Translate(Vector2.up * -1 * 0.2f);
//		}
	}
}
