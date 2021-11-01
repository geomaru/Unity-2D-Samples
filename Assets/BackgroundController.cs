using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Set Scroll Speed
    private float scrollSpeed = -1;

    // Background image dead line
    private float deadLine = -16;

    // Background image start line
    private float startLine = 15.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move background
        transform.Translate (this.scrollSpeed * Time.deltaTime, 0, 0);
        
        // Move it back to start line
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2 (this.startLine, 0);
        }

    }
}
