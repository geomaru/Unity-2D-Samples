using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //Spped of Cubes
    private float speed = -12;

    //Delete cube position
    private float deadLine = -10;
 
    // Set AudioSource as se 
    AudioSource se;

    // Start is called before the first frame update
    void Start()
    {
        // Set se as AudioSource attached in the gameobject(init)
        se = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        //Moving cube
        transform.Translate (this.speed * Time.deltaTime, 0, 0);
        
        //Delete cube once it will be outside of the window area
        if (transform.position.x < this.deadLine)
        {
            Destroy (gameObject);
        }
    }
    //FYI: OnCollisionEnter2D is inheritance class of MonoBehaviour
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        // Process for CubeTag(for Generated cubePrefab)
        if (collisionInfo.transform.tag == "CubeTag")
        {
            //If they hit collision each other, then it sound from attached from AudioSource
            se.Play();
        }
        // If the Cube touch down the ground, it also sound se
        if(collisionInfo.transform.tag =="GroundTag")
        {
            se.Play();
        }
    }
}
