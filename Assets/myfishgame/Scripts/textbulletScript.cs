using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class textbulletScript : MonoBehaviour
{


	public static textbulletScript Instance;
	public int numBullet;
	gunMoveScript gun;

	void Awake ()
	{
		Instance = this;
	}

	void Start ()
	{
		gun = gunMoveScript.Instance;
		numBullet = gun.maxBullet;
	}

	void Update ()
	{
		GetComponent<Text> ().text = numBullet.ToString ();
	}
}
