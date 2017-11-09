using UnityEngine;
using System.Collections;

public class gameConllerScript : MonoBehaviour
{
	public static gameConllerScript Instance;

	// 鱼的类型
	public GameObject[] fishPrefab;
	// 屏幕最大鱼的数量
	int maxFish = 20;
	// 当前屏幕中鱼的数量
	public int curFish = 0;

	void Start ()
	{
		AddFish ();
		curFish = maxFish;
	}

	void Awake ()
	{
		Instance = this;
	}

	void Update ()
	{
		// 屏幕鱼的数量减少就增加到最大数量
		if (curFish < maxFish) {
			AddFish ();
			curFish++;
		}
	}

	// 产生鱼的方法
	void AddFish ()
	{
		for (int i = 0; i < maxFish - curFish; i++) {
			float x = Random.Range (-Screen.width * 0.1f, Screen.width * 1.1f);
			float y = Random.Range (-Screen.height * 0.1f, Screen.height * 1.1f);
			Vector3 pos = new Vector3 (x, y, 0);
			Vector3 dir = ChangeViewTwoWorldPoint (pos, transform);
			Instantiate (fishPrefab [Random.Range (0, fishPrefab.Length)], dir, Quaternion.identity);
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
