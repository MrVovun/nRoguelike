using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour {

	public Item item;

	public void HighlightThis () {
		Debug.Log (item.name);
	}
}
