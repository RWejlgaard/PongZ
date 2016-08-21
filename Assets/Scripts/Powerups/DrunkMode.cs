﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class DrunkMode : MonoBehaviour {

    public float duration = 15;
    private bool active = false;
    private GameObject Camera;
    private Vortex vortex;
    private bool vortexReverse = false;
    void Start()
    {
        Camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        vortex = Camera.GetComponent<Vortex>();
    }

    // Update is called once per frame
    void Update()
    {
        if (duration <= 0)
        {
            vortex.enabled = false;
            vortex.angle = 0;
        }
        else if (active)
        {
            if (vortex.angle < 80f && !vortexReverse) {
                vortex.angle++;
            }
            else if (vortex.angle > -80f && vortexReverse) {
                vortex.angle--;
            }
            else if (vortex.angle > 80f && !vortexReverse) {
                vortexReverse = true;
            }
            else if (vortex.angle < -80f && vortexReverse) {
                vortexReverse = false;
            }
            duration -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Camera.GetComponent<Vortex>().enabled = true;
            active = true;
        }

        transform.position = new Vector3(1000, 1000, 0);


    }
}
