using UnityEngine;
using System.Collections;

public class FishMove : MonoBehaviour
{

	// 1.移动速度
	public float fishspeed = 5;
	// 2.鱼的方向
	public enum Direction
	{
		Right = 1,
		Left = -1
	}
	// 3.初始化鱼的移动方向
	public Direction fishDir;

    public Vector3 dir;
	// 4.鱼的目标点
	Vector3 targetPos;


	void Start ()
	{
		// 一开始，确定这条鱼的朝向
		int ran = Random.Range (0, 100);
		if (ran < 50) {
			fishDir = Direction.Right;
		} else {
			fishDir = Direction.Left;
		}
		transform.localScale = new Vector3 ((int)fishDir, 1, 1);
		// 设置目标点
		SetFishTarget ();
	}


	void SetFishTarget ()
	{
		float x = Random.Range (-Screen.width * 0.1f, Screen.width * 1.1f);
		float y = Random.Range (-Screen.height * 0.1f, Screen.height * 1.1f);
		Vector3 pos = new Vector3 (x, y, 0);
		targetPos = ChangeViewTwoWorldPoint (pos, transform);
        dir = targetPos - transform.position;
        if (targetPos.x > transform.position.x) {
			fishDir = Direction.Right;

            float angle = Vector3.Angle(Vector3.right, dir);
            if (targetPos.y > transform.position.y)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -angle);
            }
        } else {
			fishDir = Direction.Left;

            float angle = Vector3.Angle(-Vector3.right, dir);
            if (targetPos.y > transform.position.y)
            {
                transform.rotation = Quaternion.Euler(0, 0, -angle);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
      
        
        // 根据鱼的方向，调整鱼模型方向
        transform.localScale = new Vector3((int)fishDir, 1, 1);
    }

	// 鱼移动
	void fishMove ()
	{
		Vector3 pos = Vector3.MoveTowards (transform.position, targetPos, Time.deltaTime * fishspeed);
		transform.position = pos;
		if (Vector3.Distance (transform.position, targetPos) < 0.01f) {
			// 更新目标点
			SetFishTarget ();
		}
	}

	void Update ()
	{
		fishMove ();
	}

	Vector3 ChangeViewTwoWorldPoint (Vector3 pos, Transform trans)
	{
		Vector3 dir = trans.position - Camera.main.transform.position;
		Vector3 targetDir = Vector3.Project (dir, Camera.main.transform.forward);
		return Camera.main.ViewportToWorldPoint (new Vector3 (pos.x / Screen.width,
			pos.y / Screen.height, targetDir.magnitude));
	}
}
