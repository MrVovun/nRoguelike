using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

	public GameObject droppableItem;

	public void DropItem () {
		var offset = gameObject.transform.position;
		Instantiate (droppableItem, offset, Quaternion.identity);
	}
}
