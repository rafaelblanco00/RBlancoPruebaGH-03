using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{

    public XRRayInteractor XRRayInteractor_RightHand_Grab;
    public XRRayInteractor XRRayInteractor_RightHand_Teleport;

    public InputActionReference PalancaControlDerecho;

    private void Start()
    {
        XRRayInteractor_RightHand_Grab.enabled = true;
        XRRayInteractor_RightHand_Teleport.enabled = false;
    }

    public void PalancaArribaPresionada(InputAction.CallbackContext contexto)
    {
        XRRayInteractor_RightHand_Grab.enabled = false;
        XRRayInteractor_RightHand_Teleport.enabled = true;
    }

    public void PalancaArribaLiberada(InputAction.CallbackContext contexto)
    {
        Invoke("PalancaArribaLiberada_Invoke", 0.005f);
    }

    public void PalancaArribaLiberada_Invoke()
    {
        XRRayInteractor_RightHand_Grab.enabled = true;
        XRRayInteractor_RightHand_Teleport.enabled = false;
    }

    private void OnEnable()
    {
        PalancaControlDerecho.action.performed += PalancaArribaPresionada;
        PalancaControlDerecho.action.canceled += PalancaArribaLiberada;
    }

    private void OnDisable()
    {
        PalancaControlDerecho.action.performed -= PalancaArribaPresionada;
        PalancaControlDerecho.action.canceled -= PalancaArribaLiberada;
    }
}
