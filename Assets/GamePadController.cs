using UnityEngine;
using System.Collections;

public class GamePadController : MonoBehaviour {

	public float walkSpeed = 1.0f;
	public Transform head;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 f = head.forward;
		f.y = 0;
		f.Normalize ();
		Vector3 r = head.right;
		r.y = 0;
		r.Normalize ();
		Vector3 movementForward = f * walkSpeed * Input.GetAxis("Vertical");
		Vector3 movementRight = head.right * walkSpeed * Input.GetAxis("Horizontal");
		transform.Translate (movementForward + movementRight);
	}
}
