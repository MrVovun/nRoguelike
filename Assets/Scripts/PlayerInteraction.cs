using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public float force;

	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Ti pizda");
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
			GetComponent<PlayerController> ().canMove = true;
		}
	}

	void OnCollisionEnter (Collision enemy) {
		if (enemy.gameObject.tag == "Enemy") {
			Debug.Log ("Ti pidor");
			var dir = -transform.forward;
			GetComponent<Rigidbody> ().AddForce (dir * force, ForceMode.VelocityChange);
			GetComponent<PlayerController> ().canMove = false;
		}
	}
}
