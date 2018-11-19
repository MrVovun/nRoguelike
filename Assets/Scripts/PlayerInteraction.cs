using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public float force;

	void OnCollisionEnter (Collision enemy) {
		if (enemy.gameObject.tag == "Enemy") {
			CameraShaker.Instance.ShakeOnce (4f, 3f, .2f, .5f);
			var dir = -transform.forward;
			GetComponent<Rigidbody> ().AddForce (dir * force, ForceMode.VelocityChange);
			GetComponent<PlayerController> ().canMove = false;
			StartCoroutine ("Push");
			GetComponent<PlayerController> ().HP = GetComponent<PlayerController> ().HP - enemy.gameObject.GetComponent<EnemyController> ().DMG;
		}
	}

	IEnumerator Push () {
		yield return new WaitForSeconds (0.2f);
		StopPushing ();
	}

	void StopPushing () {
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		GetComponent<PlayerController> ().canMove = true;
	}

}
