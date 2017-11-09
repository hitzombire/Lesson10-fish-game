using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class fireScript : MonoBehaviour
{
	// 爆炸预设体
	public GameObject prefab;

	// 子弹速度
	public float speed = 50;
	// 子弹的伤害
	public float damage = 60;

	textScript text;

	void Start ()
	{
		// 3秒后子弹消失
		GameObject.Destroy (gameObject, 3);
		text = textScript.Instance;
	}


	void Update ()
	{
		transform.position += transform.up * speed * Time.deltaTime;

	}

	// 触发检测事件
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Fish") {
			other.GetComponent <FishHealthScript > ().UnderAttack (damage);
			GameObject.Destroy (gameObject);
			other.GetComponent <SpriteRenderer> ().material.color = Color.red;
		} 

	}


}
