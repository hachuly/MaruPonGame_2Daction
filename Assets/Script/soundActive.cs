using UnityEngine;
using System.Collections;

public class soundActive : MonoBehaviour {

    private AudioSource sound;

	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

    public void active(){
        sound.PlayOneShot(sound.clip);
    }
}
