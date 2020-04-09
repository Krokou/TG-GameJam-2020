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
    private float minjJumpHeight_F = 1;
    private float maxJumpHeight_F = 4;
    private float minZVelocity_F = 1;
    private float maxZVelocity_F = 8;
    private float minJumpRepeatRate_F = 1;
    private float maxJumpRepeatRate_F = 4;
    private float minYRot_F = 0;
    private float maxYRot_F = 360;

    //Particles
    public GameObject ParticleSpawner;
    private GameObject DustSpawner_Part;

  

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody_RGB = GetComponent<Rigidbody>();

        //Jump after 1 second and then repeat the rate randomly.
        //InvokeRepeating("KittenJumpUpdate",1, jumpRepeatRate_F);
        StartCoroutine(RepeatJump());
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yRot_F = Random.Range(minYRot_F, maxYRot_F);
      
        myRigidBody_RGB.rotation = Quaternion.Euler(0, yRot_F, 0);

        Vector3 vel = new Vector3(0, jumpHeight_F, zVelocity_F);
        //Debug.Log("vel: " + vel);

        //Add kitten new rotation to velocity.
        Vector3 newVel = Quaternion.AngleAxis(yRot_F, Vector3.up) * vel;

        //Debug.Log("newVel: " + newVel);


        myRigidBody_RGB.velocity = newVel;



       jumpRepeatRate_F = Random.Range(minJumpRepeatRate_F, maxJumpRepeatRate_F);
        Debug.Log("jumpRepeatRate_F: " + jumpRepeatRate_F);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            DustSpawner_Part = Instantiate(ParticleSpawner , transform.position , ParticleSpawner.transform.rotation) as GameObject;
            DustSpawner_Part.GetComponent<ParticleSystem>().Play();
        }
    }
}


