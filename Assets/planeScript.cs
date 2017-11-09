using UnityEngine;
using System.Collections;

public class planeScript : MonoBehaviour
{
	// 炮口的位置
	public GameObject gunObj;

	void Start ()
	{
	
	}

	void Update ()
	{
		Vector3 dir = ChangeViewTwoWorldPoint (Input.mousePosition, gunObj.transform) - gunObj.transform.position;
		print (dir.magnitude);

	}

	Vector3 ChangeViewTwoWorldPoint (Vector3 pos, Transform trans)
	{
		Vector3 dir = trans.position - Camera.main.transform.position;
		Vector3 targetDir = Vector3.Project (dir, Camera.main.transform.forward);
		return Camera.main.ViewportToWorldPoint (new Vector3 (pos.x / Screen.width,
			pos.y / Screen.height, targetDir.magnitude));
	}
}
