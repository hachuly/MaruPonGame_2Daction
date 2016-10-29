using UnityEngine;
using System.Collections;

public class timeStop : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void nowStop(Rigidbody2D rigid2D, bool trigger){
        if(trigger){
            rigid2D.velocity = Vector2.zero;
            rigid2D.isKinematic = trigger;
        }else{
            rigid2D.isKinematic = trigger;
        }


    }
}
