﻿using UnityEngine;
using System.Collections;


public class playerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	static bool firstTimeStartup = true;
	public int mia1 = 0;
	public int mia2 = 0;
	public int mia3 = 0;
	// Use this for initialization
	void Start () {
		mia1 = 0;
		mia2 = 0;
		mia3 = 0;
		if (firstTimeStartup) {
			Debug.Log("Should only be called once");
			firstTimeStartup = false;
			Time.timeScale = 0;
			menu.display_text("Attack of the Vikings");
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) 
		{mia1 = 1;
		}
		if (Input.GetKeyDown (KeyCode.I)) 
		{mia2 = 2;
		}
		if (Input.GetKeyDown (KeyCode.A)) 
		{mia3 = 0;
		}
		if (mia1 + mia2 + mia3 == 3) 
		{Debug.Log ("hello mia");
			GameObject go = GameObject.Find("easteregg");
			SpriteRenderer rend = go.GetComponent<SpriteRenderer>();
			rend.enabled = true;
		}
	}
	void FixedUpdate () {

		
		float move = Input.GetAxis ("Horizontal");
				
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
