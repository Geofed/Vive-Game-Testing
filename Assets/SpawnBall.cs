using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public GameObject ball;
	public GameObject spawner;
	public ObjectPool pool;
	private float cooldown;
	public float cooldownTime;
	// Use this for initialization
	void Start () {
		cooldown = Time.time + cooldownTime;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision) {
		if (cooldown <= Time.time) {
			if (collision.gameObject.tag == "Controller") {
				cooldown = Time.time + cooldownTime;
				pool.Spawn (spawner.transform.position);
			}
		}
	}
}
