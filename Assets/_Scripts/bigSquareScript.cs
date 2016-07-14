using UnityEngine;
using System.Collections;

public class bigSquareScript : MonoBehaviour {
	public float speed = 1;
	private Vector3 newPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		transform.position = new Vector3(newPos.x -= Time.deltaTime*speed, newPos.y, newPos.z);
	}
}
