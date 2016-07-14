using UnityEngine;
using System.Collections;

public class littleSquareScript : MonoBehaviour {
	public float speed = 1;
	private Vector3 newPos;
	private GameObject manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager");
	}

	// Update is called once per frame
	void Update () {
		newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.position = new Vector3(newPos.x -= Time.deltaTime*speed, newPos.y, newPos.z);
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "bigSquare") {
			manager.GetComponent<GameManager> ().removeFromList (gameObject);
			Destroy (gameObject);
		}
		if (col.tag == "BIGGERSquare") {
			manager.GetComponent<GameManager> ().removeFromList (gameObject);
			Destroy (gameObject);
		}
	}
}
