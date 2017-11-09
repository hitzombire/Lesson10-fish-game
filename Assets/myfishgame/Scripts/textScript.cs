using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class textScript : MonoBehaviour
{
	public static textScript Instance;
	// 分数
	public int num = 0;


	gunMoveScript gun;

	void Awake ()
	{
		Instance = this;
	}

	void Start ()
	{
		gun = gunMoveScript.Instance;
	}

	void Update ()
	{
		gameObject.GetComponent <Text> ().text = num.ToString ();
		if (num > 50) {
			gun.curBullet = gun.maxBullet;
		}
	}


}
