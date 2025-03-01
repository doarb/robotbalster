using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float bulletSpeed = 30.0f;

    private XRGrabInteractable grabbable;
    private bool isHeld = false;

    void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();

        // Écoute si l'arme est prise ou relâchée
        grabbable.selectEntered.AddListener(OnGrab);
        grabbable.selectExited.AddListener(OnRelease);

        // Écoute la gâchette pour tirer
        grabbable.activated.AddListener(FireBullet);
    }

    void OnGrab(SelectEnterEventArgs arg)
    {
        isHeld = true;
    }

    void OnRelease(SelectExitEventArgs arg)
    {
        isHeld = false;
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        if (isHeld) // Permet de tirer uniquement si l'arme est tenue
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
            Destroy(spawnedBullet, 5.0f);
        }
    }
}
