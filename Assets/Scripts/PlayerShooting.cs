using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    private AudioSource source;
    public AudioClip laserClip;
    public PlayerController PlayerController;
    public GameObject chargeLaser;
    public AudioClip chargeShotClip;

    // Start is called before the first frame update
    void Start()
    {
       source =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.F) && PlayerController.HasGun() == true)
        {
            GameObject clone = Instantiate(prefab);
            source.PlayOneShot(laserClip);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;  

        }
    else if(Input.GetKeyDown(KeyCode.C) && PlayerController.HasCharge() == true){
        GameObject chargeClone = Instantiate(chargeLaser);
            source.PlayOneShot(chargeShotClip);
            chargeClone.transform.position = shootPoint.transform.position;
            chargeClone.transform.rotation = shootPoint.transform.rotation;  
    }
    }
}