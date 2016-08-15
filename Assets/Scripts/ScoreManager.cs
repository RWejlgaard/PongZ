using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int ScoreLimit = 10;
    private int LeftScore = 0;
    private int RightScore = 0;


    public void LeftScored()
    {
        LeftScore++;
    }

    public void RightScored()
    {
        RightScore++;
    }

    public void UpdateScore()
    {
        transform.GetComponent<Text>().text = LeftScore + "  " + RightScore;
    }

    // Update is called once per frame
	void Update () {
        transform.GetComponent<Text>().text = LeftScore + "  " + RightScore;
    }
}
