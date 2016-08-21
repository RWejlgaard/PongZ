using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {

    public float duration = 10;
    private float countdown;
    private bool active = false;

    // Use this for initialization
    void Start()
    {
        duration *= 2;
        countdown = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            Time.timeScale = 1;
            countdown = duration;
        }
        else if (active)
        {
            countdown -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Ball") return;
        Time.timeScale = 2f;
        active = true;
        transform.position = new Vector3(1000, 1000, 0);
    }
}
