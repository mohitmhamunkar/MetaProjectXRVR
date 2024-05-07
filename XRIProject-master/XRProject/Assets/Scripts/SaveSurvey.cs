using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Timers;

public class SaveSurvey : MonoBehaviour
{
    private string PID;
    private string Scene_No;
    private double Err_Rate;
    private int user_Rating;
    private string url;
    private static Timer Avg_timer;
    private static int Total_Timer;

    public SaveSurvey()
    {
        PID = "FPG31";
        Scene_No = "SPH01";
        Err_Rate = 0;
        user_Rating = 9;
        url = "https://neu.co1.qualtrics.com/jfe/form/SV_3fT8qgIOPUgibki";
        Total_Timer = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.timerHandler();
    }

    private void timerHandler()
    {
        Avg_timer = new Timer(1000);
        Avg_timer.Elapsed += new ElapsedEventHandler(OnTimer);
        Avg_timer.Enabled = true;
        Avg_timer.AutoReset = false;
    }

    public static void OnTimer(object source, ElapsedEventArgs e)
    {
        Total_Timer += Total_Timer; 
        Timer theTimer = (Timer) source;
        theTimer.Interval += 1000;
        theTimer.Enabled = true;
    }

    IEnumerator sendQualtricsData()
    {
        WWWForm survey = new WWWForm();
        survey.AddField("PID", PID);
        survey.AddField("Scene_No", Scene_No);
        survey.AddField("Avg_Type_Time", calculateTime().ToString());
        survey.AddField("Avg_Error_Rate", calculateError().ToString());
        survey.AddField("User_Access_Rating", user_Rating);
        UnityWebRequest form = UnityWebRequest.Post(url, survey);
        yield return form.SendWebRequest();
    }

    private double calculateError()
    {
        //Error Rate = Total Error / Total Time;
        return 0;
    }

    private double calculateTime()
    {
        //Avg Time = Total Time / Total Sentences;
        return Total_Timer / 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
