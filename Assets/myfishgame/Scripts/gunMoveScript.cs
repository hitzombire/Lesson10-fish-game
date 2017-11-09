using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class gunMoveScript : MonoBehaviour
{
	public Image image;

	public static gunMoveScript Instance;
	textbulletScript textbullet;

	public float angle;
	// 炮管旋转限制角度
	public float limitAngle = 60;
	//子弹预设体
	public GameObject bulletPrefab;
	// 炮口
	public Transform trans;

	// 子弹最大数量
	public int maxBullet = 100;
	// 当前子弹的数量
	public int curBullet;
	// 弹夹是否有子弹
	public bool bl;
	public  int controller = 0;

	void Awake ()
	{
		Instance = this;
	}

	void Start ()
	{
		curBullet = maxBullet;
		textbullet = textbulletScript.Instance;
		bl = true;
	}

	void Update ()
	{
		// 控制炮管跟随指针移动
		// 1. 讲屏幕坐标转换为世界坐标
		Vector3 mousePos = ChangeViewTwoWorldPoint (Input.mousePosition, transform);
		Vector3 dir = mousePos - transform.position;
		// 2.求出dir与v3.up的夹角
		float angle = Vector3.Angle (Vector3.up, dir);
//		if (Mathf.Abs (angle) > 60) {
//			return;
//		} else {
//			if (mousePos.x > transform.position.x) {
//				angle = -angle;
//			} else {
//				angle = angle;
//			}
//			transform.eulerAngles = new Vector3 (0, 0, angle);
//		}

		// 2.使用四元数控制旋转
		if (Mathf.Abs (angle) < limitAngle) {
			Quaternion q = Quaternion.identity;
			q.SetFromToRotation (Vector3.up, dir);
			transform.rotation = q;
		}
		// 开火
		if (curBullet <= 0) {
			image.gameObject.SetActive (true);
		} else {
			Fire ();
		}
		textbullet.numBullet = curBullet;
	}


	// 开火方案
	void Fire ()
	{
		if (bl) {
			if (Input.GetKeyDown (KeyCode.Q)) {
				// 实例化一个子弹
				Instantiate (bulletPrefab, trans.position, trans.rotation);
				curBullet--;
				controller++;
			}
		} else {
			print ("按T换弹夹");
		}

	}


	Vector3 ChangeViewTwoWorldPoint (Vector3 pos, Transform trans)
	{
		Vector3 dir = trans.position - Camera.main.transform.position;
		Vector3 targetDir = Vector3.Project (dir, Camera.main.transform.forward);
		return Camera.main.ViewportToWorldPoint (new Vector3 (pos.x / Screen.width,
			pos.y / Screen.height, targetDir.magnitude));
	}
}
