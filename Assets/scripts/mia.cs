using UnityEngine;
using System.Collections;

public class mia : MonoBehaviour {
	public int mia1 = 0;
	public int mia2 = 0;
	public int mia3 = 0;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.M)) 
		{mia1 = 1;
		}
		if (Input.GetKeyDown (KeyCode.I)) 
		{mia2 = 1;
		}
		if (Input.GetKeyDown (KeyCode.A)) 
		{mia3 = 1;
		}
		if (mia1 + mia2 + mia3 == 3) 
		{Debug.Log ("hello mia");
			SpriteRenderer rend = GetComponent<SpriteRenderer>();
			rend.enabled = true;
		}
	}
}
