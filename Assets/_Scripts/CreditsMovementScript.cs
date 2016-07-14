using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CreditsMovementScript : MonoBehaviour {
	public GameObject theBackground;
	public float speed;
	public float endCreditsTime;
	private float endCreditsTimer;
	private Color color;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + Time.deltaTime*speed, transform.position.z);
		endCreditsTimer += Time.deltaTime;
		if (endCreditsTimer > endCreditsTime) {
			StartCoroutine ("FinishedCredits");
		}
	}

	IEnumerator FinishedCredits()
	{
		while (theBackground.GetComponent<Image> ().color.r > 0) 
		{	
			color = new Color (theBackground.GetComponent<Image> ().color.r - Time.deltaTime*0.01f, 
				theBackground.GetComponent<Image> ().color.g - Time.deltaTime*0.01f, 
				theBackground.GetComponent<Image> ().color.b - Time.deltaTime*0.01f, 
				theBackground.GetComponent<Image> ().color.a);
			theBackground.GetComponent<Image> ().color = color;
			yield return null;
		}
		SceneManager.LoadScene ("MainMenu");
		yield return null;
	}
}
