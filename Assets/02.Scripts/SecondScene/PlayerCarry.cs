using System.Linq;
using TMPro;
using UnityEngine;


public class PlayerCarry : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private bool check=false;
    public GameObject spawn;
    
    private void OnTriggerEnter(Collider other)
    {
        textMeshPro.gameObject.SetActive(true);
        check=true;
    }

    private void OnTriggerExit(Collider other)
    {
        textMeshPro.gameObject.SetActive(false);
        check = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&check)
        {

            GameObject gameObject = Instantiate(spawn);
            gameObject.transform.position = transform.position+Vector3.up;
        }
    }
}
