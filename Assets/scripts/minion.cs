using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class minion : MonoBehaviour {
	public float speed = 0.5f;
	public float throwSpeed = 6f;
	Vector2 translatedMousePosition;

	private Vector3 screenPoint;
	private Vector3 offset;
	//private Vector3 startPosition;
	private Vector3 oldMouse;
	private Vector3 mouseSpeed;
	private Vector3 cursorPosition;
	public int FLING_TOP = -2;
	private Transform stemTransform;
	private bool stunned = false;
	Animator anim;
	float prevDistance = 100000f;
	int count = 0;
	GameObject vikingFlingAudioObj;
	AudioSource vikingFlingAudio;
//	public Rigidbody2D arrowObj;
//	public Rigidbody2D arrow;
	


	// Use this for initialization
	void Start () {
		Debug.Log ("starting new bad guy");
		GameObject stem = GameObject.Find("stem");
		stemTransform = stem.GetComponent<Transform> ();
		Debug.Log ("Stem.x = " + stemTransform.position.x);
		anim = GetComponent<Animator> ();

		vikingFlingAudioObj = GameObject.Find ("VikingFlingAudio");
		vikingFlingAudio = vikingFlingAudioObj.GetComponent<AudioSource>();

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("dwarf: collide:  " + col.gameObject.name);
		if (col.gameObject.name == "audry2") {
			Debug.Log("dwarf is dying");
			Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		//rigidbody2D.velocity = (translatedMousePosition - new Vector2(transform.position.x, transform.position.y)) / Time.deltaTime;
		//LastPos = rigidbody2D.position;
//		if (stunned) {
//			var mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			Quaternion rot = Quaternion.LookRotation (transform.position - mPosition, Vector3.forward);
//			transform.rotation = rot;
//			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
//			rigidbody2D.angularVelocity = 0;
//			float distance = Vector3.Distance (transform.position, mPosition);
//			Debug.Log("dist = " + distance);
//
//
//
//		}
	}

	// Update is called once per frame
	void Update () {
//		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
//			Debug.Log("Ray hit it");
//			hitObject = hit.collider.gameObject;
//			hitObject.transform.parent = gameObject.transform;
//		}
		if (!stunned) {
			count++;
			//float distance = Vector3.Distance (transform.position, stemTransform.position);

			float distance = Vector3.Distance (transform.position, stemTransform.position);
			if (stemTransform.position.x < transform.position.x  ) { // then target is to the left
	
				// now move a little towards the target
				rigidbody2D.velocity = new Vector2 (-speed, rigidbody2D.velocity.y);
			} else {  // then the target is to the right

				// now move a little towards the target
				rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
			}

			if (distance > prevDistance && count >= 5)
			{
				speed = -speed;
				count = 0;
			}
			prevDistance = distance;
		} 
	}

	IEnumerator StunEnding()
	{
		yield return new WaitForSeconds (2);
		stunned = false;
		anim.SetBool ("stunned", false);
		audio.Stop ();
		gameObject.tag = "minion";
	}
			


	void OnMouseUp() {
	//	Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		//if (cursorPosition.y < FLING_TOP) {
		vikingFlingAudio.Play ();
		Debug.Log ("mouse up..up...and...awayyyyyy");
		mouseSpeed = oldMouse - Input.mousePosition;
		rigidbody2D.AddForce (mouseSpeed * throwSpeed * -1, ForceMode2D.Force);
		StartCoroutine (StunEnding ());
			//stunned = false;
		//}
	}
	
	void OnMouseDown(){
		Debug.Log ("mouse down");
		gameObject.tag = "stunned_minion";
		audio.Play ();
		stunned = true;
		oldMouse = Input.mousePosition;
		Debug.Log ("anim.name="+anim.name);
		anim.SetBool ("stunned", true);
		//screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		//gameObject.transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y*1.5f ,transform.localScale.z);

		//startPosition = gameObject.transform.position;
		//offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		//Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		//cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		//Debug.DrawLine (oldMouse, cursorPosition, Color.green);

//		var mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		Quaternion rot = Quaternion.LookRotation(transform.position - mPosition, Vector3.forward);
//		transform.rotation = rot;
//		transform.eulerAngles = new Vector3(0,0, transform.eulerAngles.z);
//
//		arrow =(Rigidbody2D)  Instantiate(arrowObj, transform.position, transform.rotation);
//		arrow.transform.rotation = rot;
//		arrow.transform.eulerAngles = new Vector3(0,0, arrow.transform.eulerAngles.z);
//		arrow.angularVelocity = 0;
//		line.SetPosition (0, oldMouse);
//		line.SetPosition (1, cursorPosition);


	}
	

	
	void OnMouseDrag(){
//		Debug.Log ("dragging");
//		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
//		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//		cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

		//Debug.DrawLine (oldMouse, cursorPosition, Color.green);
//
//		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
//		cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
//		//Debug.Log ("dragging: m.y = " + cursorPosition.y);
//		if (cursorPosition.y < FLING_TOP)
//			transform.position = cursorPosition;
	}
//	void OnMouseOver() {
//		Debug.Log ("bad guy: mouse over");
//	}
}
