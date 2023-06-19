using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float speed = 20;


    // Start is called before the first frame update
    void Start()
    {

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(FireBullet);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FireBullet(ActivateEventArgs args)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity= spawnPoint.forward * speed;
        Destroy(spawnedBullet,5);
            
            }
}
