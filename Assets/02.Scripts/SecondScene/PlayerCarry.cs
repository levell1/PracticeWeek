using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCarry : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private bool check=false;
    
    public GameObject SpawnObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Carryable"))
        {
            
            textMeshPro.gameObject.SetActive(true);
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Carryable"))
        {
            
            textMeshPro.gameObject.SetActive(false);
            check = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && check)
        {
            GameObject gameObject = Instantiate(SpawnObject);
            gameObject.transform.position = transform.position + Vector3.up;
        }
        
    }
}
