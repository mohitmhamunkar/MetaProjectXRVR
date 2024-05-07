using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}