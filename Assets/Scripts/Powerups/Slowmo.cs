using UnityEngine;
using System.Collections;

public class Slowmo : MonoBehaviour {

    public float duration = 10;
    private bool active = false;

	// Use this for initialization
	void Start () {
	    duration = duration/2;
	}
	
	// Update is called once per frame
	void Update () {
	    if (duration <= 0) {
	        Time.timeScale = 1;
            Destroy(gameObject);
	    }
        else if (active) {
	        duration -= Time.deltaTime;
	    }
        print(duration);
	}

	private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Ball") {
			Time.timeScale = 0.5f;
            active = true;
        }

        transform.position = new Vector3(1000,1000,0);

	
	}
}
