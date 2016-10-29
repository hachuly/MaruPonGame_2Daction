using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour {

    public string name;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D other){
        SceneManager.LoadScene(name);
    }

    public void goScene(){
        SceneManager.LoadScene(name);
    }
}
