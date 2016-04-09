using UnityEngine;
using System.Collections;

public class giant_move : MonoBehaviour 
{
	public float speed = 0.01f;
	public int wall = 100;
	public int move = 1;
	public int direction = -1;
	public int wall2 = -100;
	bool canDropBarrel = true;
	GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("player");
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("wall: collide:  " + col.gameObject.name);
		if (col.gameObject.tag == "wall") {
			rigidbody2D.velocity = new Vector2 ( speed, rigidbody2D.velocity.y);
			speed = -speed;
		}
		if (col.gameObject.name == "audry2") {
			Debug.Log("giant is dying");
			Destroy(gameObject);
			main.gameWon();
		}
	}


	// Update is called once per frame
	void Update () 
	{ 	
//		if (rigidbody2D.position.x <= wall2) 
//		{  direction = -1;
//			speed = -2;
//			speed = speed * direction;
//			direction = 1;
//			Debug.Log("turn left");
//			direction = -1;
//
//		} 
//
//		rigidbody2D.velocity = new Vector2 (move * speed, rigidbody2D.velocity.y);
		//Debug.Log ("Giant: player is "+ player.transform.position.x);

		
	} 

	
	
	IEnumerator yieldConnect()
	{

			//Debug.Log("fill amount " + img.fillAmount);
			yield return new WaitForSeconds(2);
			canDropBarrel = true;
		audio.Play ();

	}
	void FixedUpdate () 
	{
		rigidbody2D.velocity = new Vector2 ( speed, rigidbody2D.velocity.y);
		if (transform.position.x >=  player.transform.position.x - 0.1f && 
		    transform.position.x <=  player.transform.position.x + 0.1f) {
			Debug.Log("found player");
			if (canDropBarrel){
			Instantiate(Resources.Load("barell"),
			            new Vector3(transform.position.x,transform.position.y - 2f,0),Quaternion.identity);
				canDropBarrel = false;
				StartCoroutine(yieldConnect());
			}
		}
		
		//		if (rigidbody2D.position.x >= wall) 
//		{ 	speed = 2;  
//			speed = speed * direction;
//			Debug.Log("turn right");
//			direction = 1;
//			direction = -1;
//		}
	}

}
