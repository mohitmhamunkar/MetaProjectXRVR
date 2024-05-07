using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Bhaptics.Tact.Unity;
public class IntroButton : MonoBehaviour
{


    public OVRHand LHand;
    public HapticSource hapticR;
    public HapticSource hapticL;
    public TextMeshPro typedText;
    public TextMeshPro buttonText;
    public TextMeshPro displayText;
    public GameObject numpad;
    public TextMeshPro outputText;
    public static string PID;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        bool isInteracting = LHand.GetFingerIsPinching(OVRHand.HandFinger.Index) ||
    LHand.GetFingerIsPinching(OVRHand.HandFinger.Middle) ||
    LHand.GetFingerIsPinching(OVRHand.HandFinger.Ring) ||
    LHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky) ||
    LHand.GetFingerIsPinching(OVRHand.HandFinger.Thumb);
        if (isInteracting)
        {
            hapticL.Play();
        }
        else
        {
            hapticR.Play();
        }
        if (index != 1)
        {
            index = 1;
            displayText.enabled =false;
            outputText.enabled = true; 
            typedText.enabled = true;
            numpad.SetActive(true);
            buttonText.text = "Start";
        }
        else
        {
            if (outputText.text != "" && outputText.text != "Enter PID")
            {
                PID = "FP3" + outputText.text;
                PlayerPrefs.SetString("PID", PID);
                //GetComponent<SceneSelector>().LoadNextScene();
                SceneManager.LoadScene("SceneManagment");
            }

        }
    }
}
