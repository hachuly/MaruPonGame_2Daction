using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    private PlayerController player;

    private Rigidbody2D rigid2D;
    private bool trigger = true;
    private int isFrame;
    private int def;
    private bool stay;
    private bool onStop;

    public GameObject bakuhatu;

	// Use this for initialization

	void Start () {
        player = GameObject.Find("UnityChan").GetComponent<PlayerController>();
        rigid2D = GetComponent<Rigidbody2D>();
        def = 1;
	}

	// Update is called once per frame
	void Update () {
        if(stay){

            if(trigger){
                rigid2D.velocity = new Vector2( -3, rigid2D.velocity.y);
            }else{
                if(isFrame + 100 < Time.frameCount){
                    trigger = true;
                }

            }

        }

	}

    void OnTriggerStay2D(Collider2D other){
        if(player.isKill()){
            if(player.getName() == "z"){
                if(other.gameObject.tag == "tagPlayer"){
                    Destroy(gameObject);
                    Instantiate(bakuhatu, transform.position, transform.rotation);
                }
            }


        }if(other.gameObject.tag == "tagPlayer"){
            rigid2D.AddForce(transform.right * 50f);
            rigid2D.AddForce(transform.up * 80f);
            trigger = false;
            isFrame = Time.frameCount;
        }else if(other.gameObject.tag == "tagBullet"
               ||other.gameObject.tag == "tagBut"
        ){ player.skillGauge(2);
            def--;
            if(def < 0){
                Destroy(gameObject);
                Instantiate(bakuhatu, transform.position, transform.rotation);
                if(other.gameObject.tag == "tagBullet"){
                    Destroy(other.gameObject);
                }

            }

        }

    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "tagMove"){
            stay = true;
        }
    }

    public void dokan(){
        Destroy(gameObject);
        Instantiate(bakuhatu, transform.position, transform.rotation);
    }

}
