using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    private GameObject player;
    private int speed = 10;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("UnityChan");
        Rigidbody2D rig2d = GetComponent<Rigidbody2D>();
        rig2d.velocity = new Vector2(speed * player.transform.localScale.x, rig2d.velocity.y);

        Vector2 temp = transform.localScale;
        temp.x = player.transform.localScale.x;
        transform.localScale = temp;

        Destroy(gameObject, 0.8f);
	}

	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D other){
        Destroy(gameObject);
    }
}
