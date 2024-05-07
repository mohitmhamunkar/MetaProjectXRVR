using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QwertyKeyoboard : MonoBehaviour
{
    public Button button;
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
        if (outputText.text == "Enter Text")
        {
            outputText.text = "";
            outputText.text += button.ToString().Substring(0, 1);
        }
        else if (outputText.text == "")
        {
            outputText.text = "Enter Text";
        }
        else if (button.ToString().Substring(0, 5) == "SPACE")
        {
            outputText.text += " ";
        }
        else if (button.ToString().Substring(0, 2) == "<-")
        {
            outputText.text = outputText.text.Remove(outputText.text.Length - 1, 1);
            if (outputText.text == "")
            {
                outputText.text = "Enter Text";
            }
        }
        else
        {
            outputText.text += button.ToString().Substring(0, 1);
        }
    }
}
