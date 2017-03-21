using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class Hands : MonoBehaviour {

	public Transform pickup;
	private Transform hitTransform;
	private Vector3 velocity;
	private Vector3 currentPosition;
	private Vector3 lastPosition;
	private Collider[] temporaryColliders;

	// Use this for initialization
	void Start () {
		if (!VRSettings.enabled) {
			Destroy (this);
			return;
		}
		temporaryColliders = new Collider [5];
		currentPosition = this.transform.position;
		var trackedController = GetComponent<SteamVR_TrackedController>();
		if (trackedController == null)
		{
			trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
		}

		trackedController.TriggerClicked += new ClickedEventHandler(DoClick);
		trackedController.TriggerUnclicked += new ClickedEventHandler(UnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (hitTransform != null) {
			lastPosition = currentPosition;
			currentPosition = hitTransform.position;
			Vector3 distanceTravelled = currentPosition - lastPosition;
			velocity = distanceTravelled / Time.deltaTime;
		}

	}

	void UnClick(object sender, ClickedEventArgs e)
	{
		Debug.Log ("UnClick Called");
		if (hitTransform != null) {
			Rigidbody hitRigidbody = hitTransform.GetComponent<Collider> ().attachedRigidbody;
			hitTransform.parent = null;
			hitTransform = null;
			hitRigidbody.isKinematic = false;	
			hitRigidbody.velocity = velocity;
		}
	}

	void DoClick(object sender, ClickedEventArgs e)
	{
		Ray ray = new Ray(this.transform.position, transform.forward);
		Debug.Log ("DoClick Called");

		RaycastHit hitInfo;
		int len = Physics.OverlapSphereNonAlloc (pickup.position, 0.05f, temporaryColliders);
		for (int i = 0; i < len; i++) {
			Debug.Log ("Hit");
			Collider colliderC = temporaryColliders [i];
			if (colliderC.GetComponent<Pickupable> () != null) {
				Debug.Log ("pickupable");
				colliderC.transform.parent = this.transform;
				colliderC.attachedRigidbody.isKinematic = true;
				//colliderC.transform.position = this.transform.position;
				hitTransform = colliderC.transform;
				currentPosition = hitTransform.position;
				break;
			}
		}
	}
}
