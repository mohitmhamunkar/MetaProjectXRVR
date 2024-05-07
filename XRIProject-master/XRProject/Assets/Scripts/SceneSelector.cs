using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using TMPro;
using OculusSampleFramework;
using System.Diagnostics;

public class SceneSelector : MonoBehaviour
{
    public string endScene;
    static List<string> sceneNames = new List<string> { "QwertySceneController", "QwertyScenePoke", "SphericalSceneController", "SphericalScenePoke" };
    static int randIndex;
    private static int currentIndex = -1;
    public TextMeshPro textDisplay;
    public OVRHand hand;
    public GameObject controller;
    public GameObject nextObject;


    void Start()
    {
        randIndex = Random.Range(0, sceneNames.Count);
    }

    public void LoadNextScene()
    {
        currentIndex++;

        if (sceneNames.Count == 0)
        {
            SceneManager.LoadScene(endScene);
        }
        else
        {
            string name = sceneNames[randIndex];
            sceneNames.RemoveAt(randIndex);
            SceneManager.LoadScene(name);

        }
    }
    void Update()
    {
        if (sceneNames.Count == 0)
        {

            textDisplay.text = "Thank you click next to give survey";
            nextObject.SetActive(true);
        }
        else if (sceneNames[randIndex] == "QwertyScenePoke" || sceneNames[randIndex] == "SphericalScenePoke")
        {
            textDisplay.text = "Wait untill detect hands ....";

            if (hand.IsTracked)
            {
                textDisplay.text = "Move to the next keyboard where the user will use \"hands\", simply click the \"next\" button.";
                nextObject.SetActive(true);
            }
        }
        else if (sceneNames[randIndex] == "QwertySceneController" || sceneNames[randIndex] == "SphericalSceneController")
        {
            textDisplay.text = "Wait untill detect Controllers ....";
            if (controller.activeSelf)
            {
                textDisplay.text = "Move to the next keyboard where the user will use \"controllers\", simply click the \"next\" button.";
                nextObject.SetActive(true);

            }
        }


    }
}
