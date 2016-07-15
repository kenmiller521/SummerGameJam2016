using UnityEngine;
using System.Collections;

public class RotateAsteroidScript : MonoBehaviour {
	private float rotateSpeed;
	public float minRotateSpeed, maxRotateSpeed;
	private Vector3 rotationVec;
	private bool rotateClockwise;
	private int temp;
	private bool isRotating;
	// Use this for initialization
	void Start () {
		isRotating = true;
		rotateSpeed = Random.Range (minRotateSpeed, maxRotateSpeed);
		if ((int)Random.Range (0,2) == 0)
			rotateClockwise = true;
		else
			rotateClockwise = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotating) {
			if (!rotateClockwise)
				transform.Rotate (Vector3.forward * Time.deltaTime * rotateSpeed, Space.World);
			else
				transform.Rotate (Vector3.back * Time.deltaTime * rotateSpeed, Space.World);
		}
	}
	public void stopRotation()
	{
		isRotating = false;
	}
	public void startRotation()
	{
		isRotating = true;
	}
}
