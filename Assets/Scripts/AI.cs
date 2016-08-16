using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	public float maxSpeed = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var posY = GameObject.FindGameObjectsWithTag("Ball")[0].transform.position.y;
		var pos = new Vector3 (8, posY);
		//if (transform.position.y < 3.5 && transform.position.y > -3.5)
        //{
			transform.position = Vector3.Lerp(transform.position,pos, maxSpeed);
        //}
    }
}
