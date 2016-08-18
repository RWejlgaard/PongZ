using UnityEngine;
using System.Collections;

public class PowerupSpawner : MonoBehaviour {

    private GameObject[] powerups;
    public float PowerupInterval = 30;
    private float powerupCountdown;
    private bool powerupActive = false;

    // Use this for initialization
	void Start () {
	    powerups = GameObject.FindGameObjectsWithTag("Powerup");
	    powerupCountdown = PowerupInterval;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
