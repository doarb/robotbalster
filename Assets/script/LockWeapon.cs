using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockWeapon : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Emp�cher de l�cher l'arme
        grabInteractable.onSelectExited.AddListener(KeepInHand);
    }

    void KeepInHand(XRBaseInteractor interactor)
    {
        // Forcer l'arme � rester en main
        grabInteractable.interactionManager.SelectEnter((IXRSelectInteractor)interactor, grabInteractable);
    }
}
