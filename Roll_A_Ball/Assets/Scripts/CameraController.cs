using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset; // position of camera minus position of player

	// Use this for initialization
	void Start () {

		// distance between player and camera
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame; guaranteed to run after all items are processed, not just position
	void LateUpdate () {

		// when player moves, camera stays (offset distance) away
		transform.position = player.transform.position + offset;
	}
}
