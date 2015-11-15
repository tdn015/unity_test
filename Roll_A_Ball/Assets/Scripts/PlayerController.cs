using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; // shows up in inspector as a property
	public Text countText;
	public Text winText;

	private Rigidbody rb; // create RigidBody object
	private int count;

	// Initializes when game starts
	void Start ()
	{
		// Set RigidBody object to RigidBody component on Unity
		rb = GetComponent<Rigidbody> (); 
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	// physics update
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// create vector3 object and map it to (x, y, z) positions
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if(count >= 12){
			winText.text = "You win!";
		}
	}
}
