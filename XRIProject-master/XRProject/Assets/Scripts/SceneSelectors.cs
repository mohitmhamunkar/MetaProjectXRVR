using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectors : MonoBehaviour
{
    public string SceneName;

    public void SelectScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
