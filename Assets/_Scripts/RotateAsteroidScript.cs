using UnityEngine;
using System.Collections;

public class RotateAsteroidScript : MonoBehaviour {
	private float rotateSpeed;
	public float minRotateSpeed, maxRotateSpeed;
	private Vector3 rotationVec;
	private bool rotateClockwise;
	private int temp;
	// Use this for initialization
	void Start () {
		rotateSpeed = Random.Range (minRotateSpeed, maxRotateSpeed);
		if ((int)Random.Range (0,2) == 0)
			rotateClockwise = true;
		else
			rotateClockwise = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!rotateClockwise)
			transform.Rotate (Vector3.forward * Time.deltaTime*rotateSpeed, Space.World);
		else
			transform.Rotate (Vector3.back * Time.deltaTime*rotateSpeed, Space.World);
	}
}
