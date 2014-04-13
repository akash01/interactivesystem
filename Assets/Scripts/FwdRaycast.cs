using UnityEngine;
using System.Collections;

public class FwdRaycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var fwd = transform.TransformDirection(Vector3.forward);
		Color color = Color.green;
		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit, 10)){

			if (hit.collider != null) {
				color = Color.red;
				hit.collider.SendMessage ("OnRayDetect", SendMessageOptions.DontRequireReceiver);
				//print (hit.collider);
			}
		}
		Debug.DrawRay(transform.position, fwd * 5, color);
	}
}
