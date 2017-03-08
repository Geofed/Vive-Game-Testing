using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour {

	private Poolable[] pool;
	public int amount;
	public Poolable template;

	// Use this for initialization
	void Start () {
		pool = new Poolable[amount];
		for (int i = 0; i < amount; i++) {
			pool [i] = Instantiate<Poolable> (template);
			pool [i].gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject Spawn (Vector3 position) {
		for (int i = 1; i < amount; i++) {
			if (pool [i].gameObject.activeSelf == false) {
				pool [i].gameObject.SetActive (true);
				pool [i].transform.position = position;
				return pool [i].gameObject;
			}
		}
		return null;
	}
}
