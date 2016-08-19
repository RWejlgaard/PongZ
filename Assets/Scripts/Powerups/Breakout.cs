using UnityEngine;
using System.Collections;

public class Breakout : MonoBehaviour {

    public float duration = 30;
    private bool active = false;

    // Use this for initialization
    void Start()
    {
        duration = duration / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
        else if (active)
        {
            duration -= Time.deltaTime;
        }
        print(duration);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            active = true;
        }

        transform.position = new Vector3(1000, 1000, 0);


    }
}