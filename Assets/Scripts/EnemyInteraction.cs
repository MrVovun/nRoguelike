using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour {

	public float pushForce = 3f;

	private void OnCollisionEnter (Collision other) {
		if (other.gameObject.tag == "Enemy") {
			Debug.Log ("Ti pidor");
		}
	}

}
