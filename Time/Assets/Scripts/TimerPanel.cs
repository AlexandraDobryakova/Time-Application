using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;
using System;

public class TimerPanel : MonoBehaviour
{
    public GameObject textOfSeconds;
    public GameObject mainPanel;
    public GameObject timerPanel;
    public GameObject minusPlusButtons;
    public GameObject hp;
    public GameObject hm;
    public GameObject mp;
    public GameObject mm;
    public GameObject sp;
    public GameObject sm;

    public GameObject scroll1;
    public GameObject scroll2;
    public GameObject scroll3;

    public GameObject closeButton;

    static public int sec = 0;
    static public int min = 0;
    static public int hour = 0;
    public Text timerText;
    private int delta = 0;

    public Image circle;
    float hundredpercent;
    static public bool alreadyWork = false;
    public bool isWorking = false;

    public bool first = false;

    public GameObject isDonePanel;
    public GameObject startButton;

    static public int countOfSeconds;
    public void CloseTimePanel()
    {
        mainPanel.SetActive(true);
        timerPanel.SetActive(false);
    }

    private float nextActionTime = 0f;
    public float period = 1f;

    private void FixedUpdate()
    {
        
        if (Time.time > nextActionTime && isWorking)
        {
            nextActionTime += 0.02f * period;
        }

        if (isWorking)
        {
            circle.fillAmount = (hundredpercent - nextActionTime) / (hundredpercent);
        }
    }

    private void Update()
    {
        if (sec == 0 && min == 0 && hour == 0 && alreadyWork)
        {
            nextActionTime = 0f;
            isWorking = false;
            buttonStop.SetActive(false);
            buttonStart.SetActive(true);
            buttonRecet.SetActive(false);
            textOfSeconds.SetActive(false);
            delta = 0;
            circle.fillAmount = 1;
            alreadyWork = false;
            isDonePanel.SetActive(true);
            startButton.SetActive(false);
            timerText.gameObject.SetActive(false);
            circle.gameObject.SetActive(false);
            closeButton.SetActive(false);
            Handheld.Vibrate();

        }
        if (delta == 1 && (min != 0 || sec != 0 || hour != 0))
        {
            isWorking = true;
            textOfSeconds.SetActive(true);
            scroll1.SetActive(false);
            scroll2.SetActive(false);
            scroll3.SetActive(false);
            buttonStop.SetActive(true);
            buttonStart.SetActive(false);
            buttonRecet.SetActive(true);
        }

        if (sec == 0)
            sm.SetActive(false); 
        else
            sm.SetActive(true);
        if (min == 0)
            mm.SetActive(false);
        else
            mm.SetActive(true);
        if (hour == 0)
            hm.SetActive(false);
        else
            hm.SetActive(true);

        if (sec == 59)
            sp.SetActive(false);
        else
            sp.SetActive(true);
        if (min == 59)
            mp.SetActive(false);
        else
            mp.SetActive(true);
        if (hour == 99)
            hp.SetActive(false);
        else
            hp.SetActive(true);


    }

    void Start()
    {
        StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        while (true)
        {
            if (sec == 0 && delta ==1 )
            {
                if (min !=0)
                { 
                    min--;
                    sec = 60;
                }
                else if (hour != 0)
                {
                    hour--;
                    min = 59;
                    sec = 60;
                }
                else
                {
                    StartStop(0);
                }
            }
            sec -= delta;
            timerText.text = hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }

    public void StartStop(int delta)
    {
        if ((min != 0 || sec != 0 || hour != 0) && delta == 1)
            this.delta = delta;
        else this.delta = 0;

    }

    public GameObject buttonStart;
    public GameObject buttonStop;
    public GameObject buttonRecet;

    public void RecetButton()
    {
        nextActionTime = 0.2f;
        isWorking = false;
        circle.gameObject.SetActive(false);
        delta = 0;
        buttonRecet.SetActive(false);
        buttonStop.SetActive(false);
        buttonStart.SetActive(true);
        min = 0;
        hour = 0;
        sec = 0;
        timerText.text = hour.ToString("D2") + ":" + min.ToString("D2") + ":" + sec.ToString("D2");
        circle.fillAmount = 1;
        alreadyWork = false;
        textOfSeconds.SetActive(false);
        scroll1.SetActive(true);
        scroll2.SetActive(true);
        scroll3.SetActive(true);
    }

    public void ButtonsStartAndStop()
    {
        if (delta == 0)
        {
            isWorking = false;
            buttonStop.SetActive(false);
            buttonStart.SetActive(true);
        }
        else if (min != 0 || sec != 0 || hour != 0)
        {
            isWorking = true;
            buttonStop.SetActive(true);
            buttonStart.SetActive(false);
            buttonRecet.SetActive(true);
        }
    }

    public void firstStart()
    {
        if (alreadyWork == false && (min != 0 || sec != 0 || hour !=0))
        {
            first = true;
            isWorking = true;
            alreadyWork = true;
            hundredpercent = hour * 3600 + min * 60 + sec;
            countOfSeconds = hour * 3600 + min * 60 + sec;
            circle.gameObject.SetActive(true);
        }
    }

    public void ClosePanelTimeIsDone()
    {
        nextActionTime = 0.2f;
        isWorking = false;
        startButton.SetActive(true);
        isDonePanel.SetActive(false);
        textOfSeconds.SetActive(false);
        scroll1.SetActive(true);
        scroll2.SetActive(true);
        scroll3.SetActive(true);
        closeButton.SetActive(true);
    }
}
