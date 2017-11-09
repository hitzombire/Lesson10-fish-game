using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class ToggleScript : MonoBehaviour
{


	public GameObject plane;

	void Start ()
	{
		GetComponent <Toggle> ().isOn = false;
	}

	public void OnClickToggle (Toggle sender)
	{
		if (sender.isOn) {
			plane.gameObject.SetActive (true);
		} else {
			plane.gameObject.SetActive (false);
		}
	}
}
