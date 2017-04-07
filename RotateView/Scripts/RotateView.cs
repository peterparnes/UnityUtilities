// Peter Parnes, peter@parnes.com, 20170407

using UnityEngine;
using System.Collections;

public class RotateView : MonoBehaviour {

	public float turnSpeed = 40.0f;
	public Transform target;

	public float height = 2f;
	public float distance = 2f;
	public float lookYOffset = 1.4f;

	private Vector3 offsetX;
	private Vector3 offsetY;
	private Vector3 offsetLookY;

	void Start () {
		offsetX = new Vector3 (0, height, distance);
		offsetY = new Vector3 (0, 0, distance);
		offsetLookY = new Vector3 (0, lookYOffset, 0);
	}

	void LateUpdate() {
		offsetX = Quaternion.AngleAxis (Time.deltaTime * turnSpeed, Vector3.up) * offsetX;
		offsetY = Quaternion.AngleAxis (Time.deltaTime * turnSpeed, Vector3.right) * offsetY;
		transform.position = target.position + offsetX; 
		transform.LookAt(target.position+offsetLookY);
	}
}