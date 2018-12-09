﻿using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	public float force;
	public GameObject chosenItem;
	public GameObject itemPrefab;

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && chosenItem != null) {
			PickUpChosenItem ();
		}
	}

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

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Item") {
			other.GetComponent<ItemInteraction> ().HighlightThis ();
			chosenItem = other.gameObject;
		}
	}
	private void OnTriggerExit (Collider other) {
		if (other.gameObject == chosenItem) {
			chosenItem = null;
		}
	}

	void PickUpChosenItem () {
		Item currentItem = Inventory.instance.items.Find (x => x.type == chosenItem.GetComponent<ItemInteraction> ().item.type);
		if (currentItem != null && currentItem.type == chosenItem.GetComponent<ItemInteraction> ().item.type) {
			var offset = transform.position + new Vector3 (0, 0, -1);
			Instantiate (itemPrefab, offset, Quaternion.identity);
			Inventory.instance.Remove (currentItem);
			Inventory.instance.Add (chosenItem.GetComponent<ItemInteraction> ().item);
			Destroy (chosenItem);
		} else {
			Inventory.instance.Add (chosenItem.GetComponent<ItemInteraction> ().item);
			Destroy (chosenItem);
		}

	}
}
