using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroNumpad : MonoBehaviour
{
    public TextMeshPro button;
    public TextMeshPro outputText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void taskOnClick()
    {
        if(outputText.text == "Enter PID")
        {
            outputText.text = "";
            outputText.text += button.text;
        }
        else if(outputText.text == "")
        {
            outputText.text = "Enter PID";
        }
        else if(button.text == "Clear")
        {
            outputText.text = "Enter PID";
        }
        else if(button.text == "<-")
        {
            outputText.text = outputText.text.Remove(outputText.text.Length - 1, 1);
            if (outputText.text == "" || outputText.text.Length == 0)
            {
                outputText.text = "Enter PID";
            }
        }
        else
        {
            outputText.text += button.text;
        }
    }
}
