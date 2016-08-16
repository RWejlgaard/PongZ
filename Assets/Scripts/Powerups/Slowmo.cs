using UnityEngine;
using System.Collections;

public class Slowmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Ball") {
			Time.timeScale = 0.5f;
		}
	
	}
}
