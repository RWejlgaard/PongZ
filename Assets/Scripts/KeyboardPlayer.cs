using UnityEngine;
using System.Collections;

public class KeyboardPlayer : MonoBehaviour {

	float posY = 0;
	float speed = 0.7f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (posY + (Input.GetAxis ("Vertical") * speed) <= 3.5 && posY + (Input.GetAxis ("Vertical") * speed) > -3.5) {
			posY += (Input.GetAxis ("Vertical") * speed);
		}
		var pos = new Vector3(8,posY);
		if (pos.y < 3.5 && pos.y > -3.5){
			transform.position = pos;
		}
	}
}
