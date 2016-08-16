using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Pawn : MonoBehaviour {

	private bool skipFrame;
    // ReSharper disable once UnusedMember.Local
    private void Start () {
	
	}
	
    // ReSharper disable once UnusedMember.Local
    private void Update ()
	{
		var posY = Camera.main.ScreenToWorldPoint (Input.mousePosition).y;
		var pos = new Vector3 (-8, posY);
		if (pos.y < 3.5 && pos.y > -3.5) {
			transform.position = pos;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;		
		}
	}
}

