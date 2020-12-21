using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public void Backmainmeun()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
