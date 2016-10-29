using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class isCountDown : MonoBehaviour {

    private TimerController timeManager;
    private Background bar;
    private int nowTime = 1;
    private bool nowState;

	// Use this for initialization
	void Start () {
        bar = GameObject.Find("isReady").GetComponent<Background>();
	}

	// Update is called once per frame
	void Update () {
        count();
	}

    public void count(){

        if(nowTime<(int)Time.time){
            nowTime = (int)Time.time;
            redyGo();

        }
        if(nowState){
            alphaState();
        }

    }

    public void redyGo(){
        gameObject.GetComponent<Text>().text = "Go!";
        timeManager = GameObject.Find("TimerText").GetComponent<TimerController>();
        timeManager.gaming_state(true);
        nowState = true;
    }

    public void alphaState(){
        gameObject.GetComponent<Text>().color = new Color(0,0,0,gameObject.GetComponent<Text>().color.a - 0.02f);
        Destroy(GameObject.Find("isReady"));
        GameObject.Find("UnityChan").GetComponent<PlayerController>().getState(true);

        if(gameObject.GetComponent<Text>().color.a < 0){
            gameObject.SetActive(false);

        }

    }

}
