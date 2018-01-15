using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("YouWin", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}
