using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

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

    [SerializeField]
    private XRRayInteractor  leftRay;
    [SerializeField]
    private XRRayInteractor   rightRay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool isLeftValid);
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool isRightValid);


        bool isLeftPressed = leftActivate.action.ReadValue<float>() > 0.1f;
        bool isRightPressed = rightActivate.action.ReadValue<float>() > 0.1f;

        bool isLeftNotGrabbing = leftCancel.action.ReadValue<float>() == 0;
        bool isRightNotGrabbing = rightCancel.action.ReadValue<float>() == 0;

        leftTeleportation.SetActive(!isLeftRayHovering && isLeftNotGrabbing && isLeftPressed);
        rightTeleportation.SetActive(!isRightRayHovering && isRightNotGrabbing && isRightPressed);


    }
}
