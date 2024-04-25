using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElapsedTime : MonoBehaviour
{
    float time;
    TMP_Text timeText;
    string rightText;
    string leftText;

    private void OnEnable()
    {
        timeText = GetComponent<TMP_Text>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        SetTimer();
    }

    string RightTimer()
    {
        switch (time % 60)
        {
            case < 10:
                {
                    rightText = "0" + Mathf.FloorToInt(time % 60).ToString();
                    return rightText;
                }
            default:
                {
                    rightText = Mathf.FloorToInt(time % 60).ToString();
                    return rightText;
                }
        }
    }

    string LeftTimer()
    {
        switch (time)
        {
            case > 600:
                {
                    leftText = Mathf.FloorToInt(time / 60).ToString();
                    return leftText;
                }

            case > 60:
                {
                    leftText = "0" + Mathf.FloorToInt(time / 60).ToString();
                    return leftText;
                }
            default:
                {
                    leftText = "00";
                    return leftText;
                }
        }
    }

    void SetTimer()
    {
        timeText.text = LeftTimer() + ":" + RightTimer();
    }

}
