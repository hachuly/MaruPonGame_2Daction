using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class talkStart : MonoBehaviour {

    public GameObject talk;

    private string[] talkArray;
    private bool trigger;
    private int i;

	// Use this for initialization
	void Start () {
        talk = gameObject;
        setArray();
        i = 0;
        Time.timeScale = 0;
	}

	// Update is called once per frame
	void Update () {
        nextTalk();
	}

    private void nextTalk(){
        if(trigger != true){
            if(Input.GetKeyDown(KeyCode.Space)){                setComents(getComents());
            }
        }

    }

    private void setComents(string n){
        talk.GetComponent<Text>().text = n;
        i++;
        if(i > 7){
            trigger = true;
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private string getComents(){
        return talkArray[i];
    }

    private void setArray(){
        talkArray = new string[99];
        talkArray[0] = "やばいめう";
        talkArray[1] = "ここで遅刻したら人生終わるめう";
        talkArray[2] = "いやだああああああ学校行きたくないめううううう";
        talkArray[3] = "あああああああああああああああああああああああああ";
        talkArray[4] = "いやだああああああああああああああああああああああああ";
        talkArray[5] = "死にたくないいいいいいいいいいいいいいいいいいいい";
        talkArray[6] = "死にたくないめううううううううううううううううううううううう";
        talkArray[7] = "ぬあああああああああああああああああああああああああ";
        talkArray[8] = "";
        talkArray[9] = "";
        talkArray[10] = "";
        talkArray[11] = "";
        talkArray[12] = "";
        talkArray[13] = "";
        talkArray[14] = "";
        talkArray[15] = "";
    }

}
