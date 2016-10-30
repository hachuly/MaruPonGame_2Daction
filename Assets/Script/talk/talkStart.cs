using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class talkStart : MonoBehaviour {

    public GameObject talk;
    private GameObject[] isReady;



    private string[] talkArray;
    private bool trigger;
    private int i;

	// Use this for initialization
	void Start () {
        talk = gameObject;
        isReady = new GameObject[4];
        isReady[0] = GameObject.Find("isReady");
        isReady[1] = GameObject.Find("startReady");
        isReady[2] = GameObject.Find("Image_1");
        isReady[3] = GameObject.Find("Image_2");
        isReady[0].SetActive(false);
        isReady[1].SetActive(false);

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
            if(Input.GetKeyDown(KeyCode.Space)){
                setComents(getComents());
            }
        }

    }

    private void setComents(string n){
        GameObject b = GameObject.Find("UnityChan");
        talk.GetComponent<Text>().text = n;
        i++;
        if(b.GetComponent<isName>().getName() == "z"){
            if(i > 7){
            trigger = true;
                gameObject.SetActive(false);
                isReady[2].SetActive(false);
                isReady[3].SetActive(false);
                Time.timeScale = 1;
                isReady[0].SetActive(true);
                isReady[1].SetActive(true);
            }

        }else if(b.GetComponent<isName>().getName() == "x"){
            if(i > 4){
                trigger = true;
                gameObject.SetActive(false);
                isReady[2].SetActive(false);
                isReady[3].SetActive(false);
                Time.timeScale = 1;
                isReady[0].SetActive(true);
                isReady[1].SetActive(true);
            }

        }else {
            if(i > 7){
                trigger = true;
                gameObject.SetActive(false);
                isReady[2].SetActive(false);
                isReady[3].SetActive(false);
                Time.timeScale = 1;
                isReady[0].SetActive(true);
                isReady[1].SetActive(true);
            }
        }

    }

    private string getComents(){
        return talkArray[i];
    }

    private void setArray(){
        GameObject n = GameObject.Find("UnityChan");
        talkArray = new string[99];
        if(n.GetComponent<isName>().getName() == "z"){

            talkArray = new string[99];
                talkArray[0] = "今日は遠足の日！";
                talkArray[1] = "楽しみすぎて、全然眠れなかった…";
                talkArray[2] = "気が付けば、時間もないし、";
                talkArray[3] = "家の周りに変な人がうろついてる…";
                talkArray[4] = "考えていても仕方ない！";
                talkArray[5] = "死にたくないいいいいいいいいいいいいいいいいいいい";
                talkArray[6] = "全員血祭りにあげてやるわ！！";
                talkArray[7] = "ぬあああああああああああああああああああああああああ";
                    talkArray[8] = "";
                    talkArray[9] = "";
                    talkArray[10] = "";
                    talkArray[11] = "";

        }else if(n.GetComponent<isName>().getName() == "x"){

            talkArray[0] = "今日は遠足の日！";
            talkArray[1] = "でも、ネトゲのイベントのせいで寝れなかったし";
            talkArray[2] = "気が付けば、時間も無いわ";
            talkArray[3] = "とりあえず邪魔なヒトは倒して進みましょう！";
            talkArray[4] = "";
            talkArray[5] = "";
            talkArray[6] = "";
            talkArray[7] = "";
            talkArray[8] = "";
            talkArray[9] = "";
            talkArray[10] = "";
            talkArray[11] = "";
            talkArray[12] = "";
            talkArray[13] = "";
            talkArray[14] = "";
            talkArray[15] = "";
        }else {
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

}
