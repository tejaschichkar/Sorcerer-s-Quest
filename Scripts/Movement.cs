using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationSpeed = 5.0f; // speed of rotation
    public float minRotation = -360.0f; // minimum rotation angle
    public float maxRotation = 360.0f; // maximum rotation angle

    private float currentRotation = 180.0f; // current rotation angle

    public float speed = 5.0f; // speed of the character's movement

    public Rigidbody controller; // reference to the character controller component
    //public Rigidbody Player;
    public GameObject player;

    public GameObject Cube;
    public GameObject Zombie1;
    public GameObject Door1Trigger;
    public GameObject HorcruxDoor;
    public GameObject HorcruxDoor2;
    public Collider Inst5Collider;
    public GameObject Inst5Trigger;
    public GameObject Spirits1;
    public GameObject Axe1;
    public Collider ZombieTriggerC;
    public GameObject StairwayDoor1;
    public GameObject ZombieTrigger;
    public GameObject Vortex;
    [SerializeField] ParticleSystem MagicFx;
    [SerializeField] ParticleSystem VortexFx;
    public InstuctionsScript canvas;
    public HealthScript PlayerH;
    public Animator Zombie1Anim;
    // Start is called before the first frame update
    void Start()
    {
        Inst5Collider.enabled = false;
        ZombieTriggerC.enabled = false;
        Zombie1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // get horizontal mouse input
        currentRotation += mouseX * rotationSpeed; // add the mouse input to the current rotation
        currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation); // clamp the current rotation angle between the minimum and maximum values

        transform.localRotation = Quaternion.Euler(0.0f, currentRotation, 0.0f);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        // Check if the input is negative (backward) and clamp it to zero
        /*if (vertical < 0)
        {
            vertical = 0;
        }*/
        if (player.transform.position.y <= 0f) 
        {
            player.transform.Translate(0f, 0.2f, 0f);
        }
        Vector3 movement = new Vector3(0, horizontal, vertical);
        movement.Normalize(); // normalize the direction vector if it is not zero
        movement *= speed * Time.deltaTime; // scale the direction vector by the speed and time
        movement = transform.TransformDirection(movement); // transform the direction vector relative to the character's rotation
        controller.velocity = movement * speed;
        //Player.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.K))
        {
            MagicFx.Play();
            Destroy(Axe1);
            Destroy(MagicFx, 5f);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            VortexFx.Play();
            Destroy(Zombie1, 3f);
            Destroy(Vortex, 6f);
            canvas.Invoke("EnableBText", 5f);
            PlayerH.domainAffect = false;
            Destroy(StairwayDoor1, 3f);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == Cube)
        {
            canvas.EnableSText();
            Destroy(Cube);
        }
        if (col.gameObject == Door1Trigger)
        {
            canvas.EnableNText();
            Destroy(Door1Trigger);
            Destroy(HorcruxDoor);
        }
        if (col.gameObject == HorcruxDoor2)
        {
            canvas.EnableHText();
            Inst5Collider.enabled = true;
            Destroy(HorcruxDoor2);
            Destroy(Spirits1);
            Zombie1.SetActive(true);
        }
        if (col.gameObject == Inst5Trigger)
        {
            canvas.Enable5Text();
            ZombieTriggerC.enabled = true;
            Destroy(Inst5Trigger);
        }
        if (col.gameObject == ZombieTrigger)
        {
            canvas.EnableZText();
            Zombie1Anim.SetTrigger("Angry");
            Destroy(ZombieTrigger);
        }
    }
}
