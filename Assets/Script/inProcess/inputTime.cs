using UnityEngine;
using System.Collections;

public class inputTime : MonoBehaviour {

    private string time;
    private string m;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void inResult(string n){
        time = n;
    }

    public void inMinutes(string n){
        m = n;
    }

    public string getResult(){
        return time;
    }

    public string getMinutes(){
        return m;
    }

}
