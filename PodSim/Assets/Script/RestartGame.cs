using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update

    //reload the scene
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
