using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float force  = 1500f;
    public float torque = 20f;
    public float jump = 14f;
    Animator animController;
    private bool jet;
    public GameObject jetpack;
    public GameObject wallpack;
    private bool jetEquipped;
    Vector3 input;
    public float fall = 6f;
    private int numOfJumps = 1;
    public GameObject gun;
    public GameObject tableGun;
    private bool hasGun;
    private bool gunPickedUp;
    private bool hasCharge;
    private bool chargePickedUp;
    public GameObject ChargeArea;
    public GameObject ChargeShot;
    public GameObject jetEffect;
    public AudioSource source;
    public AudioClip jetClip;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animController = GetComponent<Animator> ();
        jetpack.GetComponent<MeshRenderer>().enabled = false;
        jetEquipped = false;
        animController.applyRootMotion = false;
        wallpack.GetComponent<MeshRenderer>().enabled = true;
        tableGun.GetComponent<MeshRenderer>().enabled = true;
        gun.GetComponent<MeshRenderer>().enabled = false;
        hasGun =false;
        ChargeShot.GetComponent<MeshRenderer>().enabled = false;
        ChargeArea.GetComponent<MeshRenderer>().enabled = true;
        hasCharge = false;
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Grabbing objects
        GrabObject();

        input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // updates number of jumps when jetpack is equipped
        if(Mathf.Abs(rb.velocity.y)<=0.01 && jetEquipped == true){
            numOfJumps = 2;
        }
        else if(Mathf.Abs(rb.velocity.y)<=0.01 && jetEquipped == false){
            numOfJumps = 1;
        }
        // Jumping when no jetpack is equipped
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y)<=0.01 && jetEquipped == false)
        {
            
            rb.velocity = new Vector3(rb.velocity.x,jump,rb.velocity.z);
        }
        ;

        // Enable double jump and hover when jetpack is equipped
        if(jetEquipped == true && Input.GetKeyDown(KeyCode.Space) && numOfJumps > 0){
                rb.velocity = new Vector3(rb.velocity.x,jump,rb.velocity.z);
                
                if(numOfJumps == 1){
                GameObject jetClone = Instantiate(jetEffect);
                source.PlayOneShot(jetClip);
                jetClone.transform.position=jetpack.transform.position;
                Destroy(jetClone, 1f);}
                
                numOfJumps -=1;
        }
        

    }

    void FixedUpdate()
    {

            if (input.magnitude > 0.001)
        {
            // rotations are about y axis
            rb.AddRelativeTorque(new Vector3(0, input.y * torque * Time.deltaTime, 0));

            // motion is forward/backward (about z axis)
            rb.AddRelativeForce(new Vector3(0, 0, input.z * force * Time.deltaTime));
            animController.SetBool("Walk", true);
            }

            else{
                 animController.SetBool("Walk", false);
                 rb.velocity = new Vector3(0, rb.velocity.y, 0);

            }
            if (rb.velocity.y < 0)
                {
                    rb.velocity += Vector3.up * Physics.gravity.y * (fall - 1) * Time.fixedDeltaTime;
                }
    }

    void OnTriggerEnter(Collider trigger){
        if(trigger.gameObject.CompareTag("Jetpack")){
            jet = true;
        }
        if(trigger.gameObject.CompareTag("Gun")){
            gunPickedUp = true;
        }
        if(trigger.gameObject.CompareTag("ChargeGun")){
            chargePickedUp = true;
        }

    }
    void OnTriggerExit(Collider trigger){
        if(trigger.CompareTag("Jetpack")){
            jet = false;
        }
        if(trigger.CompareTag("Gun")){
            gunPickedUp = false;
        }
        if(trigger.gameObject.CompareTag("ChargeGun")){
            chargePickedUp = false;
        }
    }

    void OnCollisionEnter(Collision collision){
                
    }

    

    void OnCollisionExit(Collision collision){
       
    }
    void GrabObject(){
        // picking up jetpack
        if(jet == true && Input.GetKeyDown(KeyCode.G)){
            jetpack.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Jetpack!");
            Destroy(wallpack);
            jetEquipped = true;
            jet = false;
            wallpack.GetComponent<MeshRenderer>().enabled = false;
        }

        // picking up the gun
        if(gunPickedUp == true && Input.GetKeyDown(KeyCode.G)){
            gun.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("Gun!");
            hasGun = true;
            Destroy(tableGun);
            gunPickedUp = false;
            tableGun.GetComponent<MeshRenderer>().enabled = false;
        }

        if(chargePickedUp == true && Input.GetKeyDown(KeyCode.G)){
            ChargeShot.GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("ChargeShot!");
            hasCharge = true;
            Destroy(ChargeArea);
            chargePickedUp = false;
            ChargeArea.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public bool HasGun(){
        return hasGun;
    }
    public bool HasCharge(){
        return hasCharge;
    }
}