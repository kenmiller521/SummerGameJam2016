using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Vector3 newPos;
	public GameManager manager;
	public GameObject ceiling,floor;
	public float speedModifier;
	public float scaleRate;
	public float speedScale;
	public float maxSpeed;
	private float defaultSpeedModifier;
	public AudioSource[] GoodHitAudioSources;
	public AudioSource[] BadHitAudioSources;
	private int audioSourcesRandomIndex;
	// Use this for initialization
	void Start () {
		defaultSpeedModifier = speedModifier;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (transform.position.x + speedModifier * speedScale, transform.position.y, transform.position.z);
		if (Input.GetKey (KeyCode.W)) 
		{		
			if (transform.position.y < ceiling.transform.position.y) 
			{	
				newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
				transform.position = new Vector3 (newPos.x, newPos.y += speedModifier, newPos.z);
			}

		}

		if (Input.GetKey (KeyCode.S)) 
		{		
			if (transform.position.y > floor.transform.position.y) 
			{	
				newPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
				transform.position = new Vector3 (newPos.x, newPos.y -= speedModifier, newPos.z);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "littleSquare") 
		{
			audioSourcesRandomIndex = Random.Range (0, GoodHitAudioSources.Length);
			GoodHitAudioSources [audioSourcesRandomIndex].PlayOneShot (GoodHitAudioSources [audioSourcesRandomIndex].clip);
			newPos = new Vector3 (col.transform.position.x, col.transform.position.y, col.transform.position.z);
			col.transform.position = new Vector3 (newPos.x, newPos.y-=10, newPos.z);
			manager.increaseSpeed ();
			transform.localScale = new Vector3 (transform.localScale.x + scaleRate, transform.localScale.y + scaleRate, transform.localScale.z + scaleRate);
			if(speedScale < maxSpeed)
				speedScale += 0.0005f;
			manager.increasePoints ();
		}
		if (col.tag == "bigSquare") 
		{
			audioSourcesRandomIndex = Random.Range (0, BadHitAudioSources.Length);
			BadHitAudioSources [audioSourcesRandomIndex].PlayOneShot (BadHitAudioSources [audioSourcesRandomIndex].clip);
			manager.decreaseSpeed ();
			newPos = new Vector3 (col.transform.position.x, col.transform.position.y, col.transform.position.z);
			col.transform.position = new Vector3 (newPos.x, newPos.y-=10, newPos.z);
			transform.localScale = new Vector3 (transform.localScale.x - scaleRate, transform.localScale.y - scaleRate, transform.localScale.z - scaleRate);
			if(speedScale >0)
				speedScale -= 0.0005f;
			manager.decreasePoints ();
		}
		if (col.tag == "BIGGERSquare") 
		{
			audioSourcesRandomIndex = Random.Range (0, BadHitAudioSources.Length);
			BadHitAudioSources [audioSourcesRandomIndex].PlayOneShot (BadHitAudioSources [audioSourcesRandomIndex].clip);
			manager.decreaseSpeed ();
			newPos = new Vector3 (col.transform.position.x, col.transform.position.y, col.transform.position.z);
			col.transform.position = new Vector3 (newPos.x, newPos.y-=10, newPos.z);
			transform.localScale = new Vector3 (transform.localScale.x - scaleRate*10, transform.localScale.y - scaleRate*10, transform.localScale.z - scaleRate*10);
			if(speedScale >0)
				speedScale -= 0.002f;
			manager.decreasePoints ();
		}
	}
	public void resetSpeedModifier()
	{
		speedModifier = defaultSpeedModifier;
	}
}
