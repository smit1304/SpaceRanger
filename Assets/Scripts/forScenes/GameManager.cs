using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public static bool pause = false;
    
    //bool hasGameended = false;
    public GameObject levelComplateUI;
    private bool isPause = false;

    public GameObject GameOverUI;
    public GameObject pausePanel;

    public void LevelComplete()
    {
        levelComplateUI.SetActive(true);

        Debug.Log("Level Complete");
    }
    public void gameOver()
    {
        GameOverUI.SetActive(true);
        GameObject.Find("bgMusic").GetComponent<AudioSource>().enabled = false;
        // if(hasGameended == false)
        // {
        // hasGameended = true;

        
        //}
    }
    public void restart()
    {
        onDeath.levelComplete = false;
        onDeath.playerIsDead = false;
        AudioManager.instance.Play("buttonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void quit()
    {
        AudioManager.instance.Play("buttonClick");
        Application.Quit();
    }
    public void nextLevel()
    {
        onDeath.levelComplete = false;
        AudioManager.instance.Play("buttonClick");
        onDeath.playerIsDead = false;

         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        //GameManager.pause = false;
    }
    public void main_menu()
    {
        onDeath.levelComplete = false;
        onDeath.playerIsDead = false;
        AudioManager.instance.Play("buttonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);

    }
   public void mainMmenu()
   {
        onDeath.levelComplete = false;
        onDeath.playerIsDead = false; 
        AudioManager.instance.Play("buttonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
   
   }
   public void pauseGame()
   {
        Time.timeScale = 0;
        AudioManager.instance.Play("buttonClick");
        GameObject.Find("bgMusic").GetComponent<AudioSource>().enabled = false;
        pausePanel.SetActive(true);
   }
   public void resumeGame()
   {
        Time.timeScale = 1;
        AudioManager.instance.Play("buttonClick");

        GameObject.Find("bgMusic").GetComponent<AudioSource>().enabled = true;

        pausePanel.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !onDeath.playerIsDead)
        {
            if (!isPause)
            {
                Time.timeScale = 0;
                isPause = true;
                pausePanel.SetActive(true);
                GameObject.Find("bgMusic").GetComponent<AudioSource>().enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                isPause = false;
                pausePanel.SetActive(false);
                GameObject.Find("bgMusic").GetComponent<AudioSource>().enabled = true;
            }
        }


    }
}
