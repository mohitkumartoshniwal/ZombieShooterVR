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


    [SerializeField]
    private InputActionProperty leftCancel;
    [SerializeField]
    private InputActionProperty rightCancel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isLeftPressed = leftActivate.action.ReadValue<float>() > 0.1f;
        bool isRightPressed = rightActivate.action.ReadValue<float>() > 0.1f;

        bool isLeftNotGrabbing = leftCancel.action.ReadValue<float>() == 0;
        bool isRightNotGrabbing = rightCancel.action.ReadValue<float>() == 0;

        leftTeleportation.SetActive(isLeftNotGrabbing && isLeftPressed);
        rightTeleportation.SetActive(isRightNotGrabbing && isRightPressed);


    }
}
