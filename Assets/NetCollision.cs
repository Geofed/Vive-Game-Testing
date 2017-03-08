using UnityEngine;
using System.Collections;

public class NetCollision : MonoBehaviour {

	public TextMesh text;
	private int score = 0;
	public AudioSource ding;

	// Use this for initialization
	void Start () {
		text.text = string.Format ("{0}", "0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision) {
		ding.Play();
		Debug.Log("sgaeRGehWERYQ");
		score += 1;
		text.text = string.Format ("{0}", score);
	}
}
