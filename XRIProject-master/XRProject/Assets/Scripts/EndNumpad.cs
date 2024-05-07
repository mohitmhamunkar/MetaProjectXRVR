using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndNumpad : MonoBehaviour
{
    public TextMeshPro button;
    public TextMeshPro outputText;
    public GameObject nextButton;
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
        nextButton.SetActive(true);
        if (outputText.text == "Enter Age")
        {
            outputText.text = "";
            outputText.text += button.text;
        }
        else if (outputText.text == "")
        {
            outputText.text = "Enter Age";
        }
        else if (button.text == "Clear")
        {
            outputText.text = "Enter Age";
        }
        else if (button.text == "<-")
        {
            outputText.text = outputText.text.Remove(outputText.text.Length - 1, 1);
            if (outputText.text == "" || outputText.text.Length == 0)
            {
                outputText.text = "Enter Age";
            }
        }
        else
        {
            outputText.text += button.text;
        }
    }
}
