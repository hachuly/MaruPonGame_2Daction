using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TimerController : MonoBehaviour {

    private GameObject TimerText;
    private string stringDay;
    private int hours;
    private int minutes;
    private int seconds;
    private int isClock = 0;
    public GameObject result;

    private bool TimeTrigger;
    private bool dayManager;
    private bool dayTrigger;
    private bool gaming;

	// Use this for initialization
	void Start () {
        this.TimerText = GameObject.Find("TimerText");
        hours = 8;
        minutes = 30;
        seconds = 0;
        dayManager = true;
        dayTrigger = true;
        stringDay = "AM ";
	}

	// Update is called once per frame
	void Update () {
        if(gaming){
            this.TimerText.GetComponent<Text>().text = stringDay + Hours(hours) + "h " + Minutes(minutes) + "m " + Seconds(seconds) + "s";
        }else{
            isClock = (int)Time.time;
        }

	}

    private string Hours(int h){

        if(dayTrigger){
            if(hours == 12){
                if(dayManager){
                    dayManager = false;
                    stringDay = "PM ";
                }else{
                    dayManager = true;
                    stringDay = "AM ";
                }
            }dayTrigger = false;
        }
        if(hours == 13){
                hours = 1;
                dayTrigger = true;
            }
        if(hours < 10){
            return "0" + hours.ToString();
        }

        return h.ToString();
    }

    private string Minutes(int m){
        if(m == 60){
            minutes = 0;
            hours++;
        }
        if(m < 10){
            return "0" + minutes.ToString();
        }

        return m.ToString();
    }

    private string Seconds(int s){
        if(isClock < (int)Time.time){
            isClock = (int)Time.time;
            seconds++;
            if(TimeTrigger){
                if(seconds == 0){
                    minutes++;
                    TimeTrigger = false;
                }
            }else{
                if(seconds % 60 != 0){
                    TimeTrigger = true;
                }
            }

        }if(seconds < 10){
                return "0" + seconds.ToString();
        }return seconds.ToString();

    }

    public void gaming_state(bool trigger){
        gaming = trigger;
    }
}
