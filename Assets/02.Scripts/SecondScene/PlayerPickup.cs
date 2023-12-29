using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private bool check = false;
    private GameObject _pickobj;

    private float _time = 0;
    private float _cycle = 3;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("carryobject"))
        {
            _pickobj = other.gameObject;
            textMeshPro.gameObject.SetActive(true);
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("carryobject"))
        {
            _pickobj = null;
            textMeshPro.gameObject.SetActive(false);
            check = false;
        }
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Q) && check)
        {
            if (_time>_cycle)
            {
                GameManager.Instance.action?.Invoke();
                _time = 0;
            }
            _pickobj.transform.position = gameObject.transform.position + Vector3.forward * 2 + Vector3.up;
        }
        if (Input.GetKeyUp(KeyCode.Q) && check)
        {
            _pickobj.transform.position = gameObject.transform.position + Vector3.forward * 3 + Vector3.up;
        }
    }
}
