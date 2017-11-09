/* SunYf  */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{

    float seconds = 0;

    int minute;
    int second;
    int hour;

    Text text_timeSpend;

    // Use this for initialization
    void Start()
    {
        text_timeSpend = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        minute = (int)(seconds / 60) % 60;
        second = (int)seconds - minute * 60 - hour * 3600;
        hour = (int)(minute / 60) % 60;

        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }
}
