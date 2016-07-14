using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour {
	public GameObject areYouSureQuitCanvas;
	// Use this for initialization
	void Start () {
		areYouSureQuitCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void openAreYouSureQuitCanvas()
	{
		areYouSureQuitCanvas.SetActive (true);
	}
	public void closeAreYouSureQuitCanvas()
	{
		areYouSureQuitCanvas.SetActive (false);
	}
	public void startButtonClicked()
	{
		SceneManager.LoadScene ("TestScene");
	}
	public void quitButtonClicked()
	{
		Application.Quit();
	}
	public void creditsButtonClicked()
	{
		SceneManager.LoadScene ("Credits");
	}
}
