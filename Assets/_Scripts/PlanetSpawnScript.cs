using UnityEngine;
using System.Collections;

public class PlanetSpawnScript : MonoBehaviour {
	public float minSpawnTime,maxSpawnTime,minScale,maxScale;
	public GameObject[] thePlanets;
	private int randIndex;
	private float randScale,randSpawnTime;
	private float timer;
	public GameObject spawnLocObject,floorObject,ceilingObject;
	private Vector3 spawnLoc;
	private GameObject planet;
	private bool hasSpawnedPlanet;
	// Use this for initialization
	void Start () {
		hasSpawnedPlanet = false;
		timer = 0;
		randIndex = Random.Range (0, thePlanets.Length);
		randScale = Random.Range (minScale, maxScale);
		randSpawnTime = Random.Range (minSpawnTime, maxSpawnTime);
		spawnLoc = spawnLocObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasSpawnedPlanet) 
		{
			//increment the timer
			timer += Time.deltaTime;
			//If the timer has reached the time limit
			if (timer > randSpawnTime) 
			{
				//A planet has been spawned, no more planets need to spawn
				hasSpawnedPlanet = true;
				//reset the timer
				timer = 0;
				//spawn the planet with a random angle
				planet = ((GameObject)Instantiate (thePlanets [randIndex], new Vector3 (spawnLocObject.transform.position.x - 1.5f, Random.Range (floorObject.transform.position.y, ceilingObject.transform.position.y), 0), Quaternion.Euler (0, 0, (int)Random.Range (0, 360))));
				//planet = (GameObject)Instantiate(thePlanets[randIndex], new Vector3(spawnLoc,Random.Range(floorObject.transform.position.y+0.5f, ceilingObject.transform.position.y-0.5f),0), Quaternion.Euler(0,0,Random.Range(0,360)));
				planet.transform.localScale = new Vector3 (randScale, randScale, 1);
			}
		}
	}
}