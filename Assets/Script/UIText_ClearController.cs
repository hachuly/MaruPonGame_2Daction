using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIText_ClearController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    public void isUIstate(bool trigger){
        GetComponent<Text>().enabled = trigger;
    }

}
