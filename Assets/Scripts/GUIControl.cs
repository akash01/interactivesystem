using UnityEngine;
using System.Collections;

public class GUIControl : MonoBehaviour {

	public Texture2D buttonImage = null;
	private bool GUIEnabled = true;
	public GameObject OVRController;
	public GameObject FirstPersonController;

	// Use this for initialization
	void Start () {
	
	}
	
	public void Update () {

		// Toggle GUI on/off
		if (Input.GetButtonDown("0")) {
			GUIEnabled = !GUIEnabled;
		}

		// Toggle between standard camera and Oculus Rift camera
		if (Input.GetButtonDown("ORToggle")) {
			// If both controllers deactivated activate standard constroller/camera
			if (!FirstPersonController.activeSelf && !OVRController.activeSelf)
			{
				FirstPersonController.SetActive(true);
			}
			else          // Toggle cameras
			{
				FirstPersonController.SetActive(!FirstPersonController.activeSelf);
				OVRController.SetActive(!OVRController.activeSelf);
			}
		}

		// Quit game on "Ecsape"
		if (Input.GetButtonDown("Quit"))
		{
			print ("TEST");
			Application.Quit();
		}
	}
	
	private void OnGUI()
	{
		if (GUIEnabled)
		{
			
			// Expression controls
			GUI.Box(new Rect(10,10,110,120), "Expression");

			// Smile button
			GUI.contentColor = Color.white;
			if (Global.expression == "smile") {GUI.contentColor = Color.red;}
			if(GUI.Button(new Rect(20,40,90,20), "Smile (1)")
			   || Event.current.Equals (Event.KeyboardEvent ("[1]"))
			   || Event.current.Equals (Event.KeyboardEvent ("1"))) {
				Global.expression = "smile";
			}

			// Frown button
			GUI.contentColor = Color.white;
			if (Global.expression == "surprise") {GUI.contentColor = Color.red;}
			if(GUI.Button(new Rect(20,70,90,20), "Surprise (2)")
			   || Event.current.Equals (Event.KeyboardEvent ("[2]"))
			   || Event.current.Equals (Event.KeyboardEvent ("2"))) {
				Global.expression = "surprise";
			}
			
			// Angry button
			GUI.contentColor = Color.white;
			if (Global.expression == "angry") {GUI.contentColor = Color.red;}
			if(GUI.Button(new Rect(20,100,90,20), "Angry (3)")
			   || Event.current.Equals (Event.KeyboardEvent ("[3]"))
			   || Event.current.Equals (Event.KeyboardEvent ("3"))) {
				Global.expression = "angry";
			}
			GUI.contentColor = Color.white;

			// Initial delay controls
			GUI.Box(new Rect(10,150,110,90), "Initial delay: " + Global.initialPause);
			
			// Increase initial delay - range 0-10
			if(GUI.Button(new Rect(20,180,90,20), "Increase (7)")
			   || Event.current.Equals (Event.KeyboardEvent ("[7]"))
			   || Event.current.Equals (Event.KeyboardEvent ("7"))) {
				if (Global.initialPause < 10) {
					Global.initialPause++;
				}
			}
			
			// Decrease initial delay - range 0-10
			if(GUI.Button(new Rect(20,210,90,20), "Decrease (4)")
			   || Event.current.Equals (Event.KeyboardEvent ("[4]"))
			   || Event.current.Equals (Event.KeyboardEvent ("4"))) {
				if (Global.initialPause > 0) {
					Global.initialPause--;
				}
			}


			// Expression delay controls
			GUI.Box(new Rect(10,260,110,90), "Mid delay: " + Global.expressionPause);
			
			// Increase expression delay - range 0-10
			if(GUI.Button(new Rect(20,290,90,20), "Increase (8)")
			   || Event.current.Equals (Event.KeyboardEvent ("[8]"))
			   || Event.current.Equals (Event.KeyboardEvent ("8"))) {
				if (Global.expressionPause < 10) {
					Global.expressionPause++;
				}
			}
			
			// Decrease expression delay - range 0-10
			if(GUI.Button(new Rect(20,320,90,20), "Decrease (5)")
			   || Event.current.Equals (Event.KeyboardEvent ("[5]"))
			   || Event.current.Equals (Event.KeyboardEvent ("5"))) {
				if (Global.expressionPause > 0) {
					Global.expressionPause--;
				}
			}
			

		}
	}

}
