using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTest : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.action += Hpupdate;
        GameManager.Instance.action += SteminaUpdate;
    }

    public void Hpupdate()
    {
            GameManager.Instance.PlayerData.hp-=1;
            
            Debug.Log("HP : "+ GameManager.Instance.PlayerData.hp);
    }
    public void SteminaUpdate()
    {
            GameManager.Instance.PlayerData.stamina-=1;
            Debug.Log("Stemina : " + GameManager.Instance.PlayerData.stamina);
    }
}
