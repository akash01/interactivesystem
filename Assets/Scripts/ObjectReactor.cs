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


		if ( thisHit && !lastHit ) 
		{
			hit = true;
			//animation.Play("SmileIn");
		}

		if ( !thisHit && lastHit ) 
		{
			hit = false;
			//animation.Play("SmileIn");
		}

		print("TEST " + hit);

		lastHit = thisHit;
		thisHit = false;


		//print (lastHit );
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
