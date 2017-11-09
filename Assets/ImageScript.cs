using UnityEngine;
using System.Collections;

public class ImageScript : MonoBehaviour
{
	gunMoveScript gun;
	// 一个弹夹的子弹数量
	public int num = 15;


	void Start ()
	{
		gun = gunMoveScript.Instance;
	}

	void Update ()
	{
		
		if (gun.controller > 0 && gun.controller <= 15) {
			ChangeBullet ();
			if (gun.controller == 15) {
				gun.bl = false;
			}
		} else if (gun.controller > 15) {
			ChangetwoBullet ();
		}
	}

	public void ChangeBullet ()
	{
		if (transform.parent.GetComponentInChildren<Transform> ()) {
			transform.GetChild (num - gun.controller).gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			if (gun.curBullet >= 15) {
				for (int i = 0; i < num; i++) {
					transform.GetChild (i).gameObject.SetActive (true);
				}
			} else {
				for (int i = 0; i < gun.curBullet; i++) {
					transform.GetChild (i).gameObject.SetActive (true);
				}
			}

			gun.bl = true;
			gun.controller = 0;
		}
	}


	public void ChangetwoBullet ()
	{
		// bl 为false时要换弹夹
		gun.bl = false;
		
		if (Input.GetKeyDown (KeyCode.T)) {
			if (gun.curBullet >= 15) {
				for (int i = 0; i < num; i++) {
					transform.GetChild (i).gameObject.SetActive (true);
				}
			} else {
				for (int i = 0; i < gun.curBullet; i++) {
					transform.GetChild (i).gameObject.SetActive (true);
				}
			}

			gun.bl = true;
			gun.controller = 0;
		}
	}
}
