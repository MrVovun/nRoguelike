using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour {

	public float force;

	private void Start () {
		GetComponent<StatsHolder> ().currentHP = GetComponent<StatsHolder> ().HP;
	}

	void OnCollisionEnter (Collision enemy) {
		if (enemy.gameObject.tag == "Player") {
			var dir = -transform.forward;
			GetComponent<Rigidbody> ().AddForce (dir * force, ForceMode.VelocityChange);
			StartCoroutine ("Push");
			GetComponent<StatsHolder> ().currentHP = GetComponent<StatsHolder> ().currentHP - enemy.gameObject.GetComponent<StatsHolder> ().DMG;
		}
	}
	IEnumerator Push () {
		yield return new WaitForSeconds (0.2f);
		StopPushing ();
	}

	void StopPushing () {
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}

}
