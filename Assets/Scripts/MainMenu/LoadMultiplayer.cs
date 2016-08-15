using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMultiplayer : MonoBehaviour {

    // Use this for initialization
    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(2);
        });
    }
}
