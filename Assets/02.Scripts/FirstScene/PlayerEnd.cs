using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerEnd : MonoBehaviour
{
    public GameObject EndUi;
    public Button _StartSceneButton;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8) 
        {
            Time.timeScale = 0.1f;
            Destroy(collision.gameObject);
            EndUi.SetActive(true);
        }
    }

    private void Start()
    {
        EndUi.SetActive(false);
        _StartSceneButton.onClick.AddListener(LoadStartScene);
    }

    private void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

}
