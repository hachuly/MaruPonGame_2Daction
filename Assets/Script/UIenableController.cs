using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIenableController : MonoBehaviour {

    private GameObject imageUI;
    private GameObject textUI;
    private GameObject timerUI;

    private UIImage_ClearController imageState;
    private UIText_ClearController textState;
    private TimerController timerState;

    // public UIController send;

	// Use this for initialization
	void Start () {
        imageUI = GameObject.Find("Result");
        textUI = GameObject.Find("GameClearText");
        timerUI = GameObject.Find("TimerText");

        imageState = imageUI.GetComponent<UIImage_ClearController>();
        textState = textUI.GetComponent<UIText_ClearController>();
        timerState = timerUI.GetComponentInParent<TimerController>();
	}

	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "tagGorl"){
            imageState.isUIstate(true);
            textState.isUIstate(true);
            timerState.gaming_state(true);
        }

    }

}
