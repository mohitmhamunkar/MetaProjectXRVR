using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyboardChoice : MonoBehaviour
{
    public TextMeshPro button;
    public GameObject nextButton;
    static TextMeshPro selectedButton;
    static Color normalColor;
    public static string selection="";

    // Start is called before the first frame update
    void Start()
    {
        selection = "Spherical Keyboard";
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void taskOnClick()
    {
        nextButton.SetActive(true);
        if (selectedButton != null)
        {
            selectedButton.color = normalColor;
        }
        normalColor = button.color;
        button.color = Color.red;
        selection = button.text;
        selectedButton = button;

    }
}
