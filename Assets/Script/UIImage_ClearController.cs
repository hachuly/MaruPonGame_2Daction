using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIImage_ClearController : MonoBehaviour {

    // Use this for initialization
    void Start () {
        GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    public void isUIstate(bool trigger){
        GetComponent<Image>().enabled = trigger;
    }

}
