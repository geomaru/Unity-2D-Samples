using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //Add Animator component 
    Animator animator;

    // Rigidbody for main character
    Rigidbody2D rigid2D;

    //The ground position
    private float groundLevel = -3.0f;

    //Jump speed Attenuation settings
    private float dump = 0.8f;

    //Jump speed 
    float jumpVelocity = 20;

    // Position of game over line
    private float deadLine = -9;

    // Start is called before the first frame update
    void Start()
    {
        // Get animation component
        this.animator = GetComponent<Animator> ();

        // Get Rigidbody2D component
        this.rigid2D = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        //For running character
        this.animator.SetFloat("Horizontal", 1);        

        // Confirm whether the character is in the ground or in the air
        bool isGround = (transform.position.y > this.groundLevel) ? false:true;
        this.animator.SetBool("isGround", isGround);

        // When the character is not touching in the ground, mute sound
        GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;

        //Compare the character is in the gound and hit Mouse Button Down
        if (Input.GetMouseButtonDown (0) && isGround)
        {
            //Add velocity to upper Y side(to the air)
            this.rigid2D.velocity = new Vector2 (0, jumpVelocity);
        }
        //If the player stop puress the Mouse, then it slightly slow down the speed by using dump
        if (Input.GetMouseButton (0) == false)
        {
                if(this.rigid2D.velocity.y > 0)
                {
                    this.rigid2D.velocity *= this.dump;
                }
        }
        //judgement of the deadline
        if (transform.position.x < this.deadLine)
        {
            // Show the Game Over in the canvas
            GameObject.Find("Canvas").GetComponent<UIController> ().GameOver ();

            //Destroy game object (main character)
            Destroy (gameObject); 
        }
    }
}
