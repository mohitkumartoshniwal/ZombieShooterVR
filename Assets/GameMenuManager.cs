using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;
    [SerializeField] 
    private InputActionProperty menuButton;

    [SerializeField]
    private Transform head;
    [SerializeField]
    private float spawnDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;    
        }

         menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
         menu.transform.forward *= -1;
    }
}
