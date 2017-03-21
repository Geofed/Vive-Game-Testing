using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour {

	public MonoBehaviour[] thisPlayerOnly;
	public GameObject[] playerGameobjects;
	public GameObject[] serverObjects;
	public GameObject head;
	public GameObject rightController;
	public GameObject leftController;

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			var manager = gameObject.AddComponent<SteamVR_ControllerManager> ();
			var playArea = gameObject.AddComponent<SteamVR_PlayArea> ();
			var headObject = head.AddComponent<SteamVR_TrackedObject> ();
			headObject.index = SteamVR_TrackedObject.EIndex.Hmd;
			rightController.AddComponent<SteamVR_TrackedObject> ();
			leftController.AddComponent<SteamVR_TrackedObject> ();
			manager.left = leftController;
			manager.right = rightController;
			manager.UpdateTargets ();
			var leftModel = new GameObject( "SteamVR_RenderModel" ).AddComponent<SteamVR_RenderModel>();
			var rightModel = new GameObject( "SteamVR_RenderModel" ).AddComponent<SteamVR_RenderModel>();
			leftModel.updateDynamically = true; // Update one per frame (see Update() method)
			leftModel.transform.SetParent(leftController.transform, false);
			rightModel.updateDynamically = true; // Update one per frame (see Update() method)
			rightModel.transform.SetParent(leftController.transform, false);

		}
		for (var i = 0; i < thisPlayerOnly.Length; i++) {
			thisPlayerOnly [i].enabled = isLocalPlayer;
		}
		for (var i = 0; i < playerGameobjects.Length; i++) {
			playerGameobjects [i].SetActive(isLocalPlayer);
		}
		for (int i = 0; i < serverObjects.Length; i++) {
			serverObjects [i].SetActive (!isLocalPlayer);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
