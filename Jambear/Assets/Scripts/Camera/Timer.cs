using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        StartCoroutine(DelayStart(5.0f));
    }

    //call this on update
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = hourCount + "." + minuteCount + "." + (int)secondsCount + "";
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    IEnumerator DelayStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        UpdateTimerUI();
    }
}
