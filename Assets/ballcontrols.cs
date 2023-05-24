using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ballcontrols : MonoBehaviour
{
    public Rigidbody ball;
    public GameObject arrow;
    public MouseOrbit cameraScript;
    private float lenScale = 1;
    private float maxScale = 10;
    
    private float forVel = 5f;
    private float yAng=0;
    bool canShoot;
    Quaternion rotationReset = Quaternion.Euler(0, 0, 0);
    public Vector3 teleportDestination;
    public AudioClip teleportSound;

    private AudioSource audioSource;


    void Start()
    {
        ball.rotation = rotationReset;
        ball.velocity = Vector3.zero;
        canShoot = true;
        ball.freezeRotation = true;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = teleportSound;

        canShoot = true;
        ball = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotationReset = Quaternion.Euler(0, yAng, 0);
        if (canShoot)
        {
            if(Input.GetKeyDown("w")){
                forVel+=1;
            }
            if(Input.GetKeyDown("s")){
                forVel-=1;
            }
            if(Input.GetKeyDown("a")){
                yAng-=15;
                transform.eulerAngles=new Vector3(0,yAng,0);
            }
            
            if(Input.GetKeyDown("d")){
                yAng+=15;
                transform.eulerAngles=new Vector3(0,yAng,0);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                ball.rotation = Quaternion.Euler(ball.rotation.eulerAngles.x+10f, ball.rotation.eulerAngles.y, ball.rotation.eulerAngles.z);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                ball.rotation = Quaternion.Euler(ball.rotation.eulerAngles.x-10f, ball.rotation.eulerAngles.y, ball.rotation.eulerAngles.z);
            }

        }
        else if (ball.velocity.magnitude <= 0.05f && !canShoot)
        {
            ball.rotation = rotationReset;
            ball.freezeRotation = true;
            ball.velocity = Vector3.zero;
            arrow.GetComponent<SpriteRenderer>().enabled = true;
            canShoot = true;
        }
        if (Input.GetMouseButtonDown(0)){
            ball.velocity=transform.forward*forVel;
            canShoot = false;
            arrow.GetComponent<SpriteRenderer>().enabled = false;
            StrokeManager.instance.AddStroke();

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "loss")
        {
            audioSource.Play();
            ball.rotation = rotationReset;
            ball.freezeRotation = true;
            ball.velocity = Vector3.zero;
            ball.transform.position = teleportDestination;
            StrokeManager.instance.ResetStrokes();
            forVel=5;

        }
    }
}
