using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public GameObject MenuUI;

    private void Start()
    {
        Time.timeScale = 1f;
        Instantiate(MenuUI);
    }
}
