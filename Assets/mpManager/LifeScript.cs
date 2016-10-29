using UnityEngine;
using System.Collections;

public class LifeScript: MonoBehaviour {

	RectTransform rt;
	private float maxGauge;
	private bool stateSkill;

	// Use this for initialization
	void Start () {

		rt = GetComponent<RectTransform> ();
		maxGauge = rt.sizeDelta.y;
		rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y - rt.sizeDelta.y);
	}

	public void LifeDown(int ap){
		if(maxGauge < rt.sizeDelta.y){
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, maxGauge);
		}else{
			rt.sizeDelta += new Vector2(0,ap);
		}if(maxGauge == rt.sizeDelta.y){
			stateSkill = true;
		}

	}

	public void skill(){
		if(stateSkill){
			rt.sizeDelta -= new Vector2(0, maxGauge);
			stateSkill = false;
		}
	}

	public bool getState(){
		return stateSkill;
	}

	public void inState(bool a){
		stateSkill = true;
	}

}
