using UnityEngine;
using UnityEngine.UI;

public class QuitOnClick : MonoBehaviour {

    // ReSharper disable once UnusedMember.Local
    private void Start() {
        transform.GetComponent<Button>().onClick.AddListener(Application.Quit);
    }
}
