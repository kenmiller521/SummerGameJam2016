using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {
	public GameObject theCanvas;
	// Use this for initialization
	void Start () {
		theCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void pauseGame()
	{
		theCanvas.SetActive (true);
	}
	public void unPauseGame()
	{
		theCanvas.SetActive (false);
	}
	public void quitGame()
	{
		Application.Quit ();
	}
}
