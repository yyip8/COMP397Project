using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void PlayGame()
    {
        // Load the game scene (replace "GameScene" with the name of your scene)
        SceneManager.LoadScene("scene2");
    }

    public void ExitGame()
    {
        // Exit the game
        Application.Quit();
    }
}
