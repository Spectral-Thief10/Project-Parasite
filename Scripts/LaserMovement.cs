using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    public GameObject laser;
    public GameObject shootPoint;
    private AudioSource source;
    public AudioClip clip;
    public float speed;
    private float delay = 2f;
    void Start()
    {
       source =  GetComponent<AudioSource>();
       Destroy(gameObject,delay);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Firing the laser
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            GameObject clone = Instantiate(laser);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;   
        }

        // moving the laser
        transform.Translate(0,speed * Time.deltaTime,0);
    }

    void OnCollisionEnter(Collision collision){
        
       
    }
}
