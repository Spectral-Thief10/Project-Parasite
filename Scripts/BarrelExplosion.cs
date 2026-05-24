using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public GameObject debris;
    private Vector3 savedWorldSpace;
    public GameObject explode;
    private AudioSource source;
    public AudioClip clip1;
    private bool exploded = false;
    private float delay = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Bullet") && exploded == false)
        {
            exploded = true;
            savedWorldSpace = gameObject.transform.position;
            
            GameObject boom = Instantiate(explode);
            boom.transform.position=savedWorldSpace;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            source.PlayOneShot(clip1);
            Invoke("SpawnDebris",delay);
        }
    }
    void SpawnDebris(){
        Instantiate(debris,savedWorldSpace,Quaternion.identity);
        Destroy(gameObject);
         
         
    }

}

