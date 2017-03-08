using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	public MonoBehaviour[] thisPlayerOnly;
	public GameObject[] playerGameobjects;

	// Use this for initialization
	void Start () {
		for (var i = 0; i < thisPlayerOnly.Length; i++) {
			thisPlayerOnly [i].enabled = isLocalPlayer;
		}
		for (var i = 0; i < playerGameobjects.Length; i++) {
			playerGameobjects [i].SetActive(isLocalPlayer);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
