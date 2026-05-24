using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShotMovement : MonoBehaviour
{
    private Rigidbody rigid;
public Transform teleportCube;
    public float speed = 10f;
      public GameObject explode;
      public AudioSource source;
      public AudioClip chargeDoorClip;
      public AudioClip enemyChargeClip;
    // Start is called before the first frame update
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
        if(collision.gameObject.CompareTag("ChargeShotDoor")){
            GameObject boom = Instantiate(explode);
            
            boom.transform.position=collision.gameObject.transform.position;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            AudioSource.PlayClipAtPoint(chargeDoorClip,transform.position,2f);
            Debug.Log("ChargeShotDoor destroyed");
            
        }
        if(collision.gameObject.CompareTag("Enemy")){
            GameObject boom = Instantiate(explode);
            AudioSource.PlayClipAtPoint(enemyChargeClip,transform.position,2f);
            boom.transform.position=collision.gameObject.transform.position;
            collision.gameObject.transform.position = teleportCube.position;
            Debug.Log("Enemy Teleported");
           
        }
        Destroy(gameObject);
        
    }
}
