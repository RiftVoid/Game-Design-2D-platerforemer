using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOver();
        }




    }

    private void GameOver()
    {

        Debug.Log("you lose haha");
        Time.timeScale = 0;
        gameOver.SetActive(true);
        //displayes game over screen
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("death"))
        {
            health -= 100f;
        }
        
        if (other.CompareTag("flag"))
        {
            Debug.Log("flag got");
            NextScene();
        }


    }

    public void NextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
}
