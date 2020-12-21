using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startmenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
