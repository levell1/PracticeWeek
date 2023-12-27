using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public Button _firstButton;
    public Button _SecondButton;

    private void Start()
    {
        _firstButton.onClick.AddListener(LoadFirstGameScene);
        _SecondButton.onClick.AddListener(LoadSecondGameScene);
    }

    private void LoadFirstGameScene()
    {
        SceneManager.LoadScene("FirstGameScene");
    }
    private void LoadSecondGameScene()
    {
        SceneManager.LoadScene("SecondGameScene");
    }
}
