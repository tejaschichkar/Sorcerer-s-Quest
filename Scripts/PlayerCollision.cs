using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerCollision : MonoBehaviour
{
    public Collider DoorwayB;
    public Collider Door1;
    public Collider Door2;
    [SerializeField] ParticleSystem DoorFx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }
    public void OpenDoor()
    {
        DoorwayB.enabled = !DoorwayB.enabled;
        Door1.enabled = !Door1.enabled;
        Door2.enabled = !Door2.enabled;
        DoorFx.Play();
    }
}
