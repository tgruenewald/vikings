using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class main : MonoBehaviour {
	public  float spawnMinionAtX = -10f;
	public float spawnMinionAtY = -2f;
	public int spawnRate = 2;
	void SpawnMinion()
	{
		Instantiate(Resources.Load("dwarf"),
		                               new Vector3(spawnMinionAtX,spawnMinionAtY,0),Quaternion.identity);

	}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnMinion", spawnRate, spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void gameOver() {
		Time.timeScale = 0;
		menu.display_text ("Game Over");
	}

	public static void gameWon() {
		Time.timeScale = 0;
		menu.display_text ("You Win!!");
	}

}
