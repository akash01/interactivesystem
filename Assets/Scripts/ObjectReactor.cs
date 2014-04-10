using UnityEngine;
using System.Collections;

public class ObjectReactor : MonoBehaviour {

	int count = 0;
	bool thisRayDetect = false;
	bool lastRayDetect = false;
	bool hit = false;
	bool lastHit = false;
	bool animationReady = true;
	GameObject globals;


	//Temp global variables
	//string localExpression = "smile";
	//int localInitialPause = 1;
	//int localExpressionPause = 1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// Set up 'hit' variable - true if raytrace hitting avatar box collider, false if not
		if ( thisRayDetect && !lastRayDetect ) 
		{
			hit = true;
		}

		if ( !thisRayDetect && lastRayDetect ) 
		{
			hit = false;
		}

		lastRayDetect = thisRayDetect;
		thisRayDetect = false;

		//TEST PRINT LINE - REMOVE
		//print(hit);

		// Trigger expression animation on first hit (when raytrace first hits collider)
		if ( hit && !lastHit ) 
		{
			if (animationReady) {
				//Stop an more animations playing until current on finished
				animationReady = false;
				//Play expression animation
				StartCoroutine(playExpression());
			}

		}
		
		if ( !thisRayDetect && lastRayDetect ) 
		{
			hit = false;
		}


	}

	public void OnRayDetect() {
		//Record of raytrace hit on this frame
		thisRayDetect = true;
	}

	//Play expression based on global variables
	IEnumerator playExpression() {
		string animationIn = "SmileIn";
		string animationOut = "SmileOut";

		//Set expression animations based on 'expression' global
		if (Global.expression == "smile") {
			animationIn = "SmileIn";
			animationOut = "SmileOut";
		}
		if (Global.expression == "frown") {
			animationIn = "frownIn";
			animationOut = "frownOut";
		}

		//Wait for initial pause (from global)
		yield return new WaitForSeconds(Global.initialPause);
		//Play in animation
		animation.Play(animationIn);
		//Wait for pause in middle of expression (from global) 
		//Plus second to allow in animation to finish
		yield return new WaitForSeconds(Global.expressionPause + 1);
		//Play out animation
		animation.Play(animationOut);
		//Wait for out animation to finish
		yield return new WaitForSeconds(1);
		//Allow a new animation to start
		animationReady = true;
	}






}
