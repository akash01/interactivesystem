using UnityEngine;
using System.Collections;

// Class just to manage global variable
// ATTACHED TO EMPTY GAME OBJECT GlobalEmptyGameObject
public class Global : MonoBehaviour {
	
	public static string expression = "smile";
	public static int initialPause = 1;
	public static int expressionPause = 2;

	// Use this for initialization
	void Start () {
		//print(expression);
		//print(initialPause);
		//print(expressionPause);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
