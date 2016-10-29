using UnityEngine;
using System.Collections;

public class mapRebound : MonoBehaviour {

    private GameObject obj;
    public float rebound;
    private Vector2 pos;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D other){
        obj = other.gameObject;
        pos = obj.transform.position;
    }
    void OnCollisionStay2D(Collision2D other){
        obj = other.gameObject;
        obj.transform.position = new Vector2(pos.x, obj.transform.position.y);
    }
}
