using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSingleplayer: MonoBehaviour
{

    public Scene scene;

    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene(1);
        });
    }
}