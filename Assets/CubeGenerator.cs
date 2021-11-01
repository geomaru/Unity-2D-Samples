using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    // Prefab of cube
    public GameObject cubePrefab;

    // delta as a time counter
    private float delta = 0;

    //　Span for cube generation
    private float span = 1.0f;

    // The position of cube generation
    private float genPosX = 12;

    //　Off set of the cube generation
    private float offsetY = 0.3f;
    // Span for cube Y-axis 
    private float spaceY = 6.9f;

    //　Off set of cube generation in 
    private float offsetX = 0.5f;
    // Cube span for X-axis
    private float spaceX = 0.4f;

    //Maximum cube block generation in 1 vertical line
    private int maxBlockNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        //Compare the delta < span (sec)
        if (this.delta > this.span)
        {
            this.delta = 0;
            //Generate block cubes as random number (1-4)
            int n = Random.Range (1, maxBlockNum+1);

            //Generate cubes by n
            for (int i = 0; i < n; i++)
            {
                //Cube generater
                GameObject go = Instantiate (cubePrefab) as GameObject;
                go.transform.position = new Vector2 (this.genPosX, this.offsetY + i * this.spaceY);
                
            }
            //This is for next cube generation timing
            this.span = this.offsetX + this.spaceX * n;
        }

    }
}
