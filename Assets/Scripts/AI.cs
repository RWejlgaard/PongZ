using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var posY = GameObject.FindGameObjectsWithTag("Ball")[0].transform.position.y;
        var pos = new Vector3(8, posY);
        if (pos.y < 3.5 && pos.y > -3.5)
        {
            transform.position = pos;
        }
    }
}
