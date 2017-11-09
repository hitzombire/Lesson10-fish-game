using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    float seconds = 120;

    int minute;
    int second;
    int millisencond;

    float timeSpend = 0.0f;
    Text text_timeSpend;
   
	// Use this for initialization
	void Start () {
        text_timeSpend = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update() {
        timeSpend += Time.deltaTime;
        seconds -= Time.deltaTime;

        //text_timeSpend.text = string.Format("{0:#######}", seconds);

        minute = (int)(seconds / 60) % 10;
        second = (int)seconds - minute * 60;
        millisencond = (int)(100 - (timeSpend - (int)timeSpend) * 100);

        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}", minute, second, millisencond);

        if (minute <= 0 && second <= 0 && millisencond <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("游戏结束");
        }
	}
}
