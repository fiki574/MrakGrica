using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("YouWin", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
