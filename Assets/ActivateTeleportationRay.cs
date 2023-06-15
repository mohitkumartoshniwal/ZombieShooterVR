using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
   private GameObject leftTeleportation;

    [SerializeField]
    private GameObject rightTeleportation;

    [SerializeField]
    private InputActionProperty leftActivate;

    [SerializeField]
    private InputActionProperty rightActivate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        leftTeleportation.SetActive(leftActivate.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);


    }
}
