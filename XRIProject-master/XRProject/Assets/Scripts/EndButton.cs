using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EndButton : MonoBehaviour
{
    public GameObject keyboardQ;
    public GameObject ageQ;
    public GameObject genderQ;
    public GameObject vrQ;
    public GameObject displayText;
    public TextMeshPro outputText;
    public GameObject endText;
    public TextMeshPro buttonText;
    public GameObject ageNumpad;
    public GameObject keyboardButtons;
    public GameObject genderButtons;
    public GameObject vrButtons;
    public GameObject nextButton;

    private string url;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        url = "https://neu.co1.qualtrics.com/jfe/form/SV_50ZWxzp9DURyYwm";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TaskOnClick()
    {
        if(index == 0)
        {
            index += 1;
            keyboardQ.SetActive(false);
            keyboardButtons.SetActive(false);
            ageQ.SetActive(true);
            ageNumpad.SetActive(true);
            outputText.enabled=true;
            nextButton.SetActive(false);
        }
        else if(index == 1)
        {
            index += 1;
            ageQ.SetActive(false);
            ageNumpad.SetActive(false);
            outputText.enabled = false;
            genderQ.SetActive(true);
            genderButtons.SetActive(true);
            nextButton.SetActive(false);
        }
        else if(index == 2)
        {
            index += 1;
            genderQ.SetActive(false);
            genderButtons.SetActive(false);
            vrQ.SetActive(true);
            vrButtons.SetActive(true);
            buttonText.text = "End";
            nextButton.SetActive(false);
        }
        else if(index == 3)
        {
           
            vrQ.SetActive(false);
            vrButtons.SetActive(false);
            StartCoroutine(sendQualtricsData());
            index += 1;
            nextButton.SetActive(false);
            displayText.SetActive(true);
        }
    }

    public IEnumerator sendQualtricsData()
    {
        WWWForm survey = new WWWForm();
        //Debug.Log("PID:");
        survey.AddField("PID", PlayerPrefs.GetString("PID"));
        survey.AddField("Key_Type", KeyboardChoice.selection);
        if (outputText.text == "Enter Age")
        {
            survey.AddField("Age", "0");
        }
        else
        {
            survey.AddField("Age", outputText.text);
        }
        survey.AddField("Gender", GenderChoice.selection);
        survey.AddField("VR_User", VRChoice.selection);
        UnityWebRequest form = UnityWebRequest.Post(url, survey);
        yield return form.SendWebRequest();
    }
}
