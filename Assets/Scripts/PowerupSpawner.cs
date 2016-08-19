using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

    private GameObject[] powerups;
    public float PowerupInterval = 30;
    private float powerupCountdown;
    private bool powerupActive = false;

    private float width = 1.7F;
    private float height = 3.5F;
    private float XCoordinate;
    private float YCoordinate;

    // Use this for initialization
    void Start () {
	    powerups = GameObject.FindGameObjectsWithTag("Powerup");
	    powerupCountdown = PowerupInterval;
    }
	
	// Update is called once per frame
	void Update () {
	    if (powerupCountdown <= 0) {
	        XCoordinate = Random.Range(width * -1, width);
            YCoordinate = Random.Range(height * -1, height);

            powerups[0].transform.position = new Vector3(XCoordinate, YCoordinate);
	        powerupCountdown = PowerupInterval;
	    }
	    else {
	        powerupCountdown -= Time.deltaTime;
	    }
	}
}