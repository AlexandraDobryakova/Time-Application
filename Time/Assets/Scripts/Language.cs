using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // main panel
    public Text timeButton;
    public Text stopwatchButton;
    public Text timerButton;
    public Text russianButton;
    public Text englishButton;
    public Text language;


    // time panel
    CultureInfo culture;

    // switch panel
    public Text startButtonSwitch;
    public Text stopButtonSwitch;
    public Text resetButtonSwitch;

    // timer panel
    public Text startButtonTimer;
    public Text stopButtonTimer;
    public Text resetButtonTimer;

    // panel is done
    public Text timeIsDone;
    public Text ok;

    private bool open = false;
    public GameObject settings;

    public static string lang = "rus";

    public void RussianLang()
    {
        timeButton.text = "Время";
        stopwatchButton.text = "Секундомер";
        timerButton.text = "Таймер";
        russianButton.text = "РУС";
        englishButton.text = "АНГ";
        language.text = "Язык";

        startButtonSwitch.text = "Старт";
        stopButtonSwitch.text = "Стоп";
        resetButtonSwitch.text = "Сбросить";

        startButtonTimer.text = "Старт";
        stopButtonTimer.text = "Стоп";
        resetButtonTimer.text = "Сбросить";

        ok.text = "Закрыть";
        timeIsDone.text = "Время вышло!";

        lang = "rus";
    }

    public void EnglishLang()
    {
        timeButton.text = "Time now";
        stopwatchButton.text = "Stopwatch";
        timerButton.text = "Timer";
        russianButton.text = "RUS";
        englishButton.text = "ENG";
        language.text = "Language";

        startButtonSwitch.text = "Start";
        stopButtonSwitch.text = "Pause";
        resetButtonSwitch.text = "Reset";

        startButtonTimer.text = "Start";
        stopButtonTimer.text = "Pause";
        resetButtonTimer.text = "Reset";

        ok.text = "Close";
        timeIsDone.text = "Time is over!";

        lang = "eng";
    }

    public void settingsButton()
    {
        if (open == false)
        {
            settings.SetActive(true);
            open = true;
        }
        else
        {
            settings.SetActive(false);
            open = false;
        }
    }
}
