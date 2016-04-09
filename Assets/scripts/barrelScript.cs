using UnityEngine;
using System.Collections;

public class barrelScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("barrel: collide:  " + col.gameObject.name);
		if (col.gameObject.name == "abyss") {
			Destroy(gameObject);
		}

		if (col.gameObject.tag == "minion") {
			Destroy(gameObject);
		}
		if (col.gameObject.name == "player") {
			main.gameOver();
		}
	}
}
