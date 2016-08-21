using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class ScaleUp : MonoBehaviour
{

    public float duration = 15;
    private bool active = false;
    private GameObject lastPlayer;
    private Ball ball;
    void Start()
    {
        lastPlayer = GameObject.FindGameObjectsWithTag("Ball")[0].GetComponent<Ball>().lastplayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration <= 0)
        {
            lastPlayer.transform.localScale = new Vector3(1, 1, 1);
            Destroy(gameObject);
        }
        else if (active)
        {
            duration -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            lastPlayer = GameObject.FindGameObjectsWithTag("Ball")[0].GetComponent<Ball>().lastplayer;
            lastPlayer.transform.localScale = new Vector3(1,2,1);
            active = true;
        }

        transform.position = new Vector3(1000, 1000, 0);


    }
}