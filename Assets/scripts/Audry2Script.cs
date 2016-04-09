using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Audry2Script : MonoBehaviour {
	GameObject lifeBar; 
	GameObject lifePercent;
	Image lifeBarImage;
	Text lifePercentText;
	Animator anim;
	// Use this for initialization


	void Start () {
		lifeBar = GameObject.Find ("PlantLifeBar");
		lifeBarImage = lifeBar.GetComponent<Image>();
		lifeBarImage.fillAmount = 1f;
		lifePercent = GameObject.Find ("PlantLifePercentText");
		lifePercentText = lifePercent.GetComponent<Text> ();
		anim = GetComponent<Animator> ();
	}
	IEnumerator yieldConnect()
	{
		
		//Debug.Log("fill amount " + img.fillAmount);
		yield return new WaitForSeconds(.5f);

		anim.SetBool ("feeding", false);
		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("Colliding");
		if (col.gameObject.tag == "minion" || col.gameObject.tag == "stunned_minion") {
			Debug.Log("dwarf is eating me");
			anim.SetBool ("feeding", true);
			StartCoroutine(yieldConnect());

			transform.parent.GetComponent<Transform>().Translate(Vector2.up * 1 * 0.2f);
			//transform.Translate(Vector2.up * 1 * 0.2f);
			audio.Play(); // eating
			if (stemScript.life < 20f)
			{
				stemScript.life++;
				lifeBarImage.fillAmount = stemScript.getLifePercent();
				lifePercentText.text = stemScript.getLifePercentText();
			}

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
