using UnityEngine;
using System.Collections;

public class chopperScript : MonoBehaviour {
	public float throwSpeed = 6f;
	Vector2 translatedMousePosition;
	
	private Vector3 screenPoint;
	private Vector3 offset;
	//private Vector3 startPosition;
	private Vector3 oldMouse;
	private Vector3 mouseSpeed;
	private Vector3 cursorPosition;
	public int FLING_TOP = -2;

	// Update is called once per frame
	void Update () {
		//		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit)) {
		//			Debug.Log("Ray hit it");
		//			hitObject = hit.collider.gameObject;
		//			hitObject.transform.parent = gameObject.transform;
		//		}

	}
	void OnMouseUp() {
		if (cursorPosition.y < FLING_TOP) {
			Debug.Log ("mouse up..up...and...awayyyyyy");
			mouseSpeed = oldMouse - Input.mousePosition;
			GetComponent<Rigidbody2D>().AddForce (mouseSpeed * throwSpeed * -1, ForceMode2D.Force);

		}
	}
	
	void OnMouseDown(){
		Debug.Log ("mouse down");

		oldMouse = Input.mousePosition;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		//startPosition = gameObject.transform.position;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag(){
		
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		//Debug.Log ("dragging: m.y = " + cursorPosition.y);
		if (cursorPosition.y < FLING_TOP)
			transform.position = cursorPosition;
	}
}
