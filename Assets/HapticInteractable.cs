using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

[System.Serializable]
  class Haptic{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float intensity;

    [SerializeField]
    private float duration;

    public void TriggerHaptic(BaseInteractionEventArgs baseInteractionEventArgs)
    {
        if(baseInteractionEventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

     void TriggerHaptic(XRBaseController xRBaseController)
    {
        if(intensity > 0.0f)
        {
            xRBaseController.SendHapticImpulse(intensity, duration);
        }
    }

   
}

public class HapticInteractable : MonoBehaviour
{
    [SerializeField]
     Haptic hapticOnActivated;
    

    [SerializeField]
    private Haptic hapticHoverEntered;

    [SerializeField]
    private Haptic hapticHoverExited;

    [SerializeField]
    private Haptic hapticSelectEntered;

    [SerializeField]
    private Haptic hapticSelectExited;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);


        interactable.hoverEntered.AddListener(hapticHoverEntered.TriggerHaptic);
        interactable.hoverExited.AddListener(hapticHoverExited.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticSelectEntered.TriggerHaptic);
        interactable.selectExited.AddListener(hapticSelectExited.TriggerHaptic);



    }

   
}
