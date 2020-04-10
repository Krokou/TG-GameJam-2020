using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenController : MonoBehaviour
{
    private Rigidbody myRigidBody_RGB;

    private float jumpHeight_F = 1;
    private float zVelocity_F = 2;

    //Repeat rate for repeating the jump function.
    private float jumpRepeatRate_F = 2;

    //Rotation for the kitten.
    private float yRot_F = 0;
    
    //Variables for randomizing.
    private float minjJumpHeight_F = 1f;
    private float maxJumpHeight_F = 4f;
    private float minZVelocity_F = 1f;
    private float maxZVelocity_F = 8f;
    private float minJumpRepeatRate_F = 1;
    private float maxJumpRepeatRate_F = 4;
    private float minYRot_F = 0;
    private float maxYRot_F = 360;

    //Particles
    public GameObject ParticleSpawner;
    private GameObject DustSpawner_Part;

    private Transform player_TF;

    //private bool isGrounded_B = false;

  

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody_RGB = GetComponent<Rigidbody>();
        player_TF = GameObject.FindGameObjectWithTag("Player").transform;

        //Jump after 1 second and then repeat the rate randomly.
        //InvokeRepeating("KittenJumpUpdate",1, jumpRepeatRate_F);
        StartCoroutine(RepeatJump());
       
    }

    // Update is called once per frame
    void Update()
    {
        //JumpAwayFromPlayer();
    }

    private IEnumerator RepeatJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(jumpRepeatRate_F);            
            KittenJumpUpdate();      
           
        }
    }

    
    //Jump randomly in the direction the kitten is facing.
    private void KittenJumpUpdate ()
    {

        //Debug.Log("kitten jump");
        GetComponent<Animator>().SetTrigger("StrechTrigger");
        GetComponent<Animator>().SetBool("SquashBool", false);
        GetComponent<Animator>().SetTrigger("SquashTrigger");

        jumpHeight_F = Random.Range(minjJumpHeight_F, maxJumpHeight_F);
        zVelocity_F = Random.Range(minZVelocity_F, maxZVelocity_F);

        if (Vector3.Distance(transform.position, player_TF.position) < 5)
        {
            Debug.Log("Too close!");

            float tempRot = player_TF.rotation.eulerAngles.y;

            Debug.Log("tempRot: " + tempRot);

            myRigidBody_RGB.rotation = Quaternion.Euler(0, tempRot, 0);
            yRot_F = tempRot;

            Debug.Log("yRot_F: " + yRot_F);
            /*
            Vector3 direction_V3 = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;

            Quaternion tempRot = Quaternion.LookRotation(direction_V3);
            //Quaternion rot = transform.rotation;
            yRot_F = tempRot.y;
            
            //transform.rotation = rot;
            */
        }
        else
        {
            yRot_F = Random.Range(minYRot_F, maxYRot_F);
            Debug.Log("yRot_F: " + yRot_F);
            myRigidBody_RGB.rotation = Quaternion.Euler(0, yRot_F, 0);
        }

        
      
        

        Vector3 vel = new Vector3(0, jumpHeight_F, zVelocity_F);
        //Debug.Log("vel: " + vel);

        //Add kitten new rotation to velocity.
        Vector3 newVel = Quaternion.AngleAxis(yRot_F, Vector3.up) * vel;

        //Debug.Log("newVel: " + newVel);


        myRigidBody_RGB.velocity = newVel;

        //isGrounded_B = false;

        jumpRepeatRate_F = Random.Range(minJumpRepeatRate_F, maxJumpRepeatRate_F);
        //Debug.Log("jumpRepeatRate_F: " + jumpRepeatRate_F);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            //isGrounded_B = true;

            DustSpawner_Part = Instantiate(ParticleSpawner , transform.position , ParticleSpawner.transform.rotation) as GameObject;
            DustSpawner_Part.GetComponent<ParticleSystem>().Play();
        }
    }

    private void JumpAwayFromPlayer()
    {
        if(Vector3.Distance(transform.position, player_TF.position) < 5)
        {
            Debug.Log("Too close!");
            Vector3 direction_V3 = transform.position - player_TF.position;

            Quaternion temprRot = Quaternion.LookRotation(direction_V3);
            Quaternion rot = transform.rotation;
            rot.y = temprRot.y;
            transform.rotation = rot;
        }
       
    }
}


