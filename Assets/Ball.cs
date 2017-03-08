using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float lifeSpan;
	private float life;
	private Rigidbody body;

	void OnEnable () {
		body = GetComponent<Rigidbody> ();
		life = lifeSpan;
		body.velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (body.isKinematic == false) {
			life -= Time.deltaTime;
			if (life <= 0) {
				gameObject.SetActive (false);
			}
		} else {
			life = lifeSpan;
		}
	}
}
