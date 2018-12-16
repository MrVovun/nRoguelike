using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float turnSpeed = 10;
	public bool canMove = true;

	Vector2 input;
	float angle;
	Rigidbody rb;

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
		if (GetComponent<StatsHolder> ().currentHP <= 0) {
			Death ();
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
		var koeff = transform.position + transform.forward * GetComponent<StatsHolder> ().speed * Time.deltaTime;
		rb.MovePosition (koeff);
	}

	void Death () {
		Debug.Log ("You died");
		canMove = false;
	}

}
