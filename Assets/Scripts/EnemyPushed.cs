using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPushed : MonoBehaviour {

	public float force;

	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Ti pizda");
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		}
	}

	void OnCollisionEnter (Collision enemy) {
		if (enemy.gameObject.tag == "Player") {
			Debug.Log ("Ti pidor");
			var dir = -transform.forward;
			GetComponent<Rigidbody> ().AddForce (dir * force, ForceMode.VelocityChange);
		}
	}
}
