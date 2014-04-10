using UnityEngine;
using System.Collections;

public class ObjectReactor : MonoBehaviour {

	int count = 0;
	bool lastHit = false;
	bool thisHit = false;
	bool hit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Set up 'hit' variable - true if raytrace hitting avatar box collider, false if not
		if ( thisHit && !lastHit ) 
		{
			hit = true;
		}

		if ( !thisHit && lastHit ) 
		{
			hit = false;
		}
							//TEST PRINT LINE - REMOVE
							print(hit);
		lastHit = thisHit;
		thisHit = false;
		
		// Trigger expression animation on first hit (when raytrace first hits collider)

	}

	public void OnRayDetect() {
		//print("Upps, detected " + count);
		thisHit = true;
		count++;
		//animation.Play("SmileIn");
		StartCoroutine(Pause());
		//animation.Play("SmileOut");

	}

	IEnumerator Pause() {
		//animation.Play("SmileIn");
		yield return new WaitForSeconds(1);
		//animation.Play("SmileOut");

	}
}
