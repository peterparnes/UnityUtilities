﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorState { Open, Animating, Closed };

public class SlidingDoor : MonoBehaviour {

	public float slidingDistance = 4.0f; 
	public float duration = 1.5f;
	public AnimationCurve JumpCurve = new AnimationCurve ();

	private Transform _transform = null; 
	private Vector3 _openPos = Vector3.zero;
	private Vector3 _closedPos = Vector3.zero;
	private DoorState _doorState = DoorState.Closed;

	// Use this for initialization
	void Start () {
		_transform = transform;
		_closedPos = transform.position;
		_openPos = transform.position + transform.right * slidingDistance;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && _doorState != DoorState.Animating) {
			StartCoroutine (AnimateDoor ((_doorState==DoorState.Open)?DoorState.Closed:DoorState.Open));
		}
	}

	IEnumerator AnimateDoor(DoorState newState) {
		_doorState = DoorState.Animating;
		float time = 0.0f; 
		Vector3 startPos = (newState == DoorState.Open) ? _closedPos : _openPos;
		Vector3 endPos = (newState == DoorState.Open) ? _openPos : _closedPos;

		while (time <= duration) {
			float t = time / duration;
			_transform.position = Vector3.Lerp (startPos, endPos, JumpCurve.Evaluate (t));
			time += Time.deltaTime;
			yield return null; 
		}

		_transform.position = endPos;

		_doorState = newState;
	}
}
