using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultiplayerPawn : MonoBehaviour
{

    public InputField IpInput;
    public Button ListenButton;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0;
        if (IpInput != null)
        {
            IpInput.onEndEdit.AddListener(val =>
            {
                if (!Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyDown(KeyCode.KeypadEnter)) return;
                if (!Connect(IpInput.text)) return;
                Time.timeScale = 1;
                IpInput.enabled = false;
                IpInput.transform.position = new Vector3(1000, 1000);
            });
        }
    }



    private bool Connect(string arg0)
    {
        return true;
    }
}
