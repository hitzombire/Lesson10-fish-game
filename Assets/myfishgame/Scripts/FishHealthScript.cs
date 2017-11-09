using UnityEngine;
using System.Collections;

public class FishHealthScript : MonoBehaviour
{
	gunMoveScript gun;
	//　鱼的生命值
	public float totleHp = 1f;
	// 鱼的当前生命值
	private float curHp;
	// 爆炸预设体
	public GameObject expPrefab;

	public int number;
	gameConllerScript game;

	textScript text;



	void Start ()
	{
		gun = gunMoveScript.Instance;
		curHp = totleHp;
		game = gameConllerScript.Instance;
		text = textScript.Instance;

	}

	void Update ()
	{
		// 判断鱼是否死亡
		if (curHp <= 0) {
			// 播放爆炸效果
			GameObject obj = Instantiate (expPrefab, transform.position, Quaternion.identity)as GameObject;
			GameObject.Destroy (obj.gameObject, 1);
			// 鱼消失
			GameObject.Destroy (gameObject); 
			// 告诉gameConllerScript脚本当前屏幕鱼的数量减少
			game.curFish--;
			text.num += number;
		}
	}

	// 鱼受到伤害的方法
	public void UnderAttack (float damage)
	{
		curHp -= damage;
	}
}
