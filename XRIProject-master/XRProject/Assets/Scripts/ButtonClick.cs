using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    Button start;
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        start = startButton.GetComponent<Button>();
        start.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string scene = SceneManager.GetSceneByName("SampleScene").name;
        SceneManager.LoadScene(scene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
