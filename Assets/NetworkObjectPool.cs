using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkObjectPool : NetworkBehaviour {

	private Poolable[] pool;
	public int amount;
	public Poolable template;

	// Use this for initialization
	void Start () {
		if (!isServer)
			return;
		pool = new Poolable[amount];
		for (int i = 0; i < amount; i++) {
			pool [i] = Instantiate<Poolable> (template);
			NetworkServer.Spawn (pool[i].gameObject);
			pool [i].gameObject.SetActive (false);
		}
	}


	public void CmdSpawn (Vector3 position) {
		for (int i = 1; i < amount; i++) {
			if (pool [i].gameObject.activeSelf == false) {
				pool [i].gameObject.SetActive (true);
				RpcMakeActive (pool [i].GetComponent<NetworkIdentity> ().netId);
				pool [i].transform.position = position;
				return;
			}
		}
	}
		
	public void Spawn (Vector3 position) {
		if (!isServer)
			return;
		CmdSpawn (position);
	}

	[ClientRpc]
	void RpcMakeActive(NetworkInstanceId id) {
		ClientScene.FindLocalObject (id).SetActive (true);
	}

}
