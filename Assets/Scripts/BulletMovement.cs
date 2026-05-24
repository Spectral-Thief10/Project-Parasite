using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigid;
    public Transform teleportCube;
    public float speed;
    public GameObject explode;
    public AudioSource source;
    public AudioClip doorClip;
    public AudioClip teleportClip;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
        teleportCube = GameObject.FindGameObjectWithTag("TeleportCube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime,0);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("RegularShotDoor")){
            GameObject boom = Instantiate(explode);
            boom.transform.position=collision.gameObject.transform.position;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            source = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(doorClip,transform.position,2f);
            Debug.Log("RegularShotDoor destroyed");
        }

        if(collision.gameObject.CompareTag("Enemy")){
            GameObject boom = Instantiate(explode);
            boom.transform.position=collision.gameObject.transform.position;
            collision.gameObject.transform.position = teleportCube.position;
            source = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(teleportClip,transform.position,2f);
            Debug.Log("Enemy Teleported");
        }
        Destroy(gameObject);
    }
}
