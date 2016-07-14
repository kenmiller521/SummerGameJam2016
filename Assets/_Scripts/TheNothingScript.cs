using UnityEngine;
using System.Collections;

public class TheNothingScript : MonoBehaviour {
	public GameManager manager;
	public float speed;
	private float defaultSpeed;
	// Use this for initialization
	void Start () {
		defaultSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + Time.deltaTime * speed, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			manager.gameOver ();
		}
		if (col.tag == "littleSquare") 
		{
			//Debug.Log ("Little Square Destroyed");
			manager.removeFromList (col.gameObject);
			Destroy (col.gameObject);
		}
		if (col.tag == "bigSquare") 
		{
			//Debug.Log ("Big Square Destoryed");
			manager.removeFromList (col.gameObject);
			Destroy (col.gameObject);
		}
		if (col.tag == "BIGGERSquare") 
		{
			//Debug.Log ("Big Square Destoryed");
			manager.removeFromList (col.gameObject);
			Destroy (col.gameObject);
		}
	}
	public void resetSpeed()
	{
		defaultSpeed = speed;
	}
}
