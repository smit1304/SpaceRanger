using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenuScript : MonoBehaviour
{
  public void start()
    {
        AudioManager.instance.Play("buttonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit()
    {
        AudioManager.instance.Play("buttonClick");
        Application.Quit();
    }
}
