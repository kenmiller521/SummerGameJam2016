using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject theNothing;
	public GameObject SpawnLocationObject;
	public GameObject LittleSquare,BigSquare,BIGGERSquare;
	public GameObject ceiling,floor;
	public float LitSqSpwnInter,BigSqSpwnInter,patternedBlocksSpwnInter, BIGGERSqSpwnInter;
	private float littleSquareTimer,bigSquareTimer,patternedTimer, BIGGERSquareTimer;
	private List<GameObject> LittleSquareList = new List<GameObject>();
	private List<GameObject> BigSquareList = new List<GameObject>();
	private List<GameObject> BIGGERSquareList = new List<GameObject>();
	public float squareSpeedAmount;
	public float maxSpeedAmount;
	public float LS_minSpawnTime,BS_minSpawnTime;
	public GameObject[] patternedBlocks;
	private bool gameIsPaused;
	public GameObject backgroundStars,backgroundNebula;
	public GameObject gameOverCanvas;
	public GameObject areYouSureQuitCanvas,areYouSureMainMenuCanvas,warpDriveCanvas;
	public int pointsNeededToWarp;
	private int currentPoints;
	public ParticleSystem playerPartSystem;
	// Use this for initialization
	void Start () {
		squareSpeedAmount = 3;
		gameIsPaused = false;
		gameOverCanvas.SetActive (false);
		areYouSureMainMenuCanvas.SetActive (false);
		areYouSureQuitCanvas.SetActive (false);
		warpDriveCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentPoints >= pointsNeededToWarp) {
			warpDriveCanvas.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				completedLevel ();
			}
		} 
		else 
		{
			warpDriveCanvas.SetActive (false);
		}
		//If the game is not paused and the player presses P to pause the game
		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
		{
			if (!gameIsPaused) {
				pauseGame ();
			} 
			else 
			{
				unPauseGame ();
			}
		}
		littleSquareTimer += Time.deltaTime;
		bigSquareTimer += Time.deltaTime;
		patternedTimer += Time.deltaTime;
		BIGGERSquareTimer += Time.deltaTime; 
		if (!gameIsPaused) {
			if (littleSquareTimer > LitSqSpwnInter) {
				littleSquareTimer = 0;
				LittleSquareList.Add ((GameObject)Instantiate (LittleSquare, new Vector3 (SpawnLocationObject.transform.position.x, Random.Range (floor.transform.position.y, ceiling.transform.position.y), 0), Quaternion.identity));
				LittleSquareList [LittleSquareList.Count - 1].GetComponent<littleSquareScript> ().speed = squareSpeedAmount;
				//Instantiate(LittleSquare, new Vector3(SpawnLocationObject.transform.position.x, Random.Range(floor.transform.position.y,ceiling.transform.position.y), 0), Quaternion.identity);
			}
			if (bigSquareTimer > BigSqSpwnInter) {
				bigSquareTimer = 0;
				BigSquareList.Add ((GameObject)Instantiate (BigSquare, new Vector3 (SpawnLocationObject.transform.position.x, Random.Range (floor.transform.position.y, ceiling.transform.position.y), 0), Quaternion.identity));
				BigSquareList [BigSquareList.Count - 1].GetComponent<bigSquareScript> ().speed = squareSpeedAmount;
				//Instantiate(BigSquare, new Vector3(SpawnLocationObject.transform.position.x, Random.Range(floor.transform.position.y,ceiling.transform.position.y), 0), Quaternion.identity);

			}
			if (BIGGERSquareTimer > BIGGERSqSpwnInter) {
				BIGGERSquareTimer = 0;
				BIGGERSquareList.Add ((GameObject)Instantiate (BIGGERSquare, new Vector3 (SpawnLocationObject.transform.position.x, Random.Range (floor.transform.position.y, ceiling.transform.position.y), 0), Quaternion.identity));
				BIGGERSquareList [BIGGERSquareList.Count - 1].GetComponent<bigSquareScript> ().speed = squareSpeedAmount;
				//Instantiate(BigSquare, new Vector3(SpawnLocationObject.transform.position.x, Random.Range(floor.transform.position.y,ceiling.transform.position.y), 0), Quaternion.identity);

			}
			if (patternedTimer > patternedBlocksSpwnInter) {
				patternedTimer = 0;
				GameObject obj = (GameObject)Instantiate (patternedBlocks [Random.Range (0, patternedBlocks.Length)], new Vector3 (SpawnLocationObject.transform.position.x, Random.Range (floor.transform.position.y, ceiling.transform.position.y), 0), Quaternion.identity);
				obj.GetComponent<littleSquareScript> ().speed = squareSpeedAmount;
			}
		}
	}
	public void removeFromList(GameObject obj)
	{
		if (obj.tag == "littleSquare") {
			LittleSquareList.Remove (obj);
		}
		if (obj.tag == "bigSquare") {
			BigSquareList.Remove (obj);
		}
		if (obj.tag == "BIGGERSquare") {
			BIGGERSquareList.Remove (obj);
		}
	}
	public void increaseSpeed()
	{
		if(squareSpeedAmount < maxSpeedAmount)
			squareSpeedAmount += 0.5f;
		if(LitSqSpwnInter > LS_minSpawnTime)
			LitSqSpwnInter -= 0.1f;
		if(BigSqSpwnInter > BS_minSpawnTime)
			BigSqSpwnInter -= 0.1f;
		for (int i = 0; i < LittleSquareList.Count; i++) 
		{
			LittleSquareList [i].GetComponent<littleSquareScript> ().speed = squareSpeedAmount;
		}
		for (int i = 0; i < BigSquareList.Count; i++) {
			BigSquareList [i].GetComponent<bigSquareScript> ().speed = squareSpeedAmount;
		}
		for (int i = 0; i < BIGGERSquareList.Count; i++) {
			BIGGERSquareList [i].GetComponent<bigSquareScript> ().speed = squareSpeedAmount;
		}
	}
	public void decreaseSpeed()
	{
		if(squareSpeedAmount > 0.5)
			squareSpeedAmount -= 0.5f;
		if(LitSqSpwnInter < 1)
			LitSqSpwnInter += 0.1f;
		if(BigSqSpwnInter < 1)
			BigSqSpwnInter += 0.1f;
		for (int i = 0; i < LittleSquareList.Count; i++) 
		{
			LittleSquareList [i].GetComponent<littleSquareScript> ().speed = squareSpeedAmount;
		}
		for (int i = 0; i < BigSquareList.Count; i++) {
			BigSquareList [i].GetComponent<bigSquareScript> ().speed = squareSpeedAmount;
		}
		for (int i = 0; i < BIGGERSquareList.Count; i++) {
			BIGGERSquareList [i].GetComponent<bigSquareScript> ().speed = squareSpeedAmount;
		}
	}
	public void pauseGame()
	{
		Time.timeScale = 0;
		player.GetComponent<PlayerController> ().speedModifier = 0;
		theNothing.GetComponent<TheNothingScript> ().speed = 0;
		gameIsPaused = true;
		gameObject.GetComponent<PauseMenuScript> ().theCanvas.SetActive (true);
		backgroundStars.GetComponent<littleSquareScript> ().speed = 0;
		backgroundNebula.GetComponent<littleSquareScript> ().speed = 0;
	}
	public void unPauseGame()
	{
		Time.timeScale = 1;
		player.GetComponent<PlayerController> ().resetSpeedModifier ();
		theNothing.GetComponent<TheNothingScript> ().resetSpeed ();
		gameIsPaused = false;
		gameObject.GetComponent<PauseMenuScript> ().theCanvas.SetActive (false);
		backgroundStars.GetComponent<littleSquareScript> ().speed = 0.05f;
		backgroundStars.GetComponent<littleSquareScript> ().speed = 0.15f;
		areYouSureQuitCanvas.SetActive (false);
		areYouSureMainMenuCanvas.SetActive (false);			
	}
	public void gameOver()
	{
		Time.timeScale = 0;
		player.GetComponent<PlayerController> ().speedModifier = 0;
		theNothing.GetComponent<TheNothingScript> ().speed = 0;
		gameIsPaused = true;
		backgroundStars.GetComponent<littleSquareScript> ().speed = 0;
		backgroundNebula.GetComponent<littleSquareScript> ().speed = 0;
		gameOverCanvas.SetActive (true);
	}
	public void openAreYouSureMainMenuCanvas()
	{
		areYouSureMainMenuCanvas.SetActive (true);
	}
	public void openAreYouSureQuitCanvas()
	{
		areYouSureQuitCanvas.SetActive (true);
	}
	public void closeAreYouSureMainMenuCanvas()
	{
		areYouSureMainMenuCanvas.SetActive(false);
	}
	public void closeAreYouSureQuitCanvas()
	{
		areYouSureQuitCanvas.SetActive (false);
	}
	public void restartGame()
	{
		SceneManager.LoadScene ("TestScene");
		unPauseGame ();
	}
	public void returnToMainMenu()
	{
		unPauseGame ();
		SceneManager.LoadScene ("MainMenu");
	}
	public void quitGame()
	{
		Application.Quit ();
	}
	public void increasePoints()
	{
		currentPoints += 1;
		Debug.Log (currentPoints);
	}
	public void decreasePoints()
	{
		currentPoints -= 1;
		Debug.Log (currentPoints);
	}
	void completedLevel()
	{
		playerPartSystem.Play ();
		player.GetComponent<PlayerController> ().speedModifier = 0;
		theNothing.GetComponent<TheNothingScript> ().speed = 0;
		gameIsPaused = true;
		backgroundStars.GetComponent<littleSquareScript> ().speed = 0;
		backgroundNebula.GetComponent<littleSquareScript> ().speed = 0;
		for (int i = 0; i < LittleSquareList.Count; i++) 
		{
			LittleSquareList [i].GetComponent<littleSquareScript> ().speed = 0;
		}
		for (int i = 0; i < BigSquareList.Count; i++) {
			BigSquareList [i].GetComponent<bigSquareScript> ().speed = 0;
			BigSquareList [i].GetComponent<RotateAsteroidScript> ().stopRotation ();
		}
		for (int i = 0; i < BIGGERSquareList.Count; i++) {
			BIGGERSquareList [i].GetComponent<bigSquareScript> ().speed = 0;
			BIGGERSquareList [i].GetComponent<RotateAsteroidScript> ().stopRotation ();
		}
		StartCoroutine ("Warp");
	}

	IEnumerator Warp()
	{
		
		yield return new WaitForSeconds(1.5f);
		while (player.transform.localScale.y > 1) 
		{
			player.transform.position = new Vector3 (player.transform.position.x + 0.25f, player.transform.position.y, 
				player.transform.position.z);
			player.transform.localScale = new Vector3 (player.transform.localScale.x + 1, 
				player.transform.localScale.y - 1, 
				player.transform.localScale.z);
			yield return null;
		}
		Debug.Log ("DONE");
		playerPartSystem.Stop ();
		while (player.transform.localScale.x < 30) 
		{
			player.transform.position = new Vector3 (player.transform.position.x + 0.25f, player.transform.position.y, 
				player.transform.position.z);
			player.transform.localScale = new Vector3 (player.transform.localScale.x + 1, 
				player.transform.localScale.y, 
				player.transform.localScale.z);
			yield return null;
		}

		while (player.transform.position.x < SpawnLocationObject.transform.position.x) 
		{
			player.transform.position = new Vector3 (player.transform.position.x + 1f, player.transform.position.y, 
				player.transform.position.z);
			yield return null;
		}
		SceneManager.LoadScene ("TestScene");
		unPauseGame ();
		//yield return null;
	}

}
