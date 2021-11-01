using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //GameOver text message
    private GameObject gameOverText;

    // Run Length Counter
    private GameObject runLengthText;

    //　Run length
    private float len = 0;

    // Running Spped
    private float speed = 5f;

    //　GameOver setting
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Find a game object from the scene
        this.gameOverText = GameObject.Find ("GameOver");
        this.runLengthText = GameObject.Find ("RunLength");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isGameOver == false )
        {
        // Update the run length
        this.len += this.speed * Time.deltaTime;

        // Show the length in the text component
        this.runLengthText.GetComponent<Text>().text = "Distance:  " + len.ToString ("F2") + "m";

        }
        //Compare Game Over
        if (this.isGameOver == true)
        {
            //If the player click, then reload
            if (Input.GetMouseButtonDown(0))
            {
                //relead the Scene
                SceneManager.LoadScene ("SampleScene");
            }
        }
    }
    public void GameOver()
    {
        //Show up the Game over text when the player found the game over
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;
    }
}
