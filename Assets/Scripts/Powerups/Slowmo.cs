using UnityEngine;
using System.Collections;

public class Slowmo : MonoBehaviour {

    public float duration = 10;
    private float countdown;
    private bool active = false;

	// Use this for initialization
	void Start () {
	    duration = duration/2;
        countdown = duration;
	}
	
	// Update is called once per frame
	void Update () {
	    if (countdown <= 0) {
	        Time.timeScale = 1;
            transform.position = new Vector3(1000, 1000, 0);
            countdown = duration;
            active = false;
        }
        else if (active) {
	        countdown -= Time.deltaTime;
	    }
	}

	private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Ball") {
			Time.timeScale = 0.5f;
            active = true;
        }

        transform.position = new Vector3(1000,1000,0);
	}
}
