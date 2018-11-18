using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float velocity = 5;
	public float turnSpeed = 10;

	Vector2 input;
	float angle;
	Rigidbody rb;
	public bool canMove = true;

	Quaternion targetRotation;

	private void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		GetInput ();
		if (Mathf.Abs (input.x) < 1 && Mathf.Abs (input.y) < 1) return;

		CalculateDirection ();
		Rotate ();
		if (canMove == true) {
			Move ();
		}
	}

	void GetInput () {
		input.x = Input.GetAxisRaw ("Horizontal");
		input.y = Input.GetAxisRaw ("Vertical");
	}

	void CalculateDirection () {
		angle = Mathf.Atan2 (input.x, input.y);
		angle = Mathf.Rad2Deg * angle;
	}

	void Rotate () {
		targetRotation = Quaternion.Euler (0, angle, 0);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
	}

	void Move () {
		var koeff = transform.position + transform.forward * velocity * Time.deltaTime;
		rb.MovePosition (koeff);
	}

}
