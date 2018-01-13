using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string ID;
    public Rigidbody2D Player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (ID == "LoadLevel2")
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        else if (ID == "LoadLevel3")
            Debug.Log("Level 3 not yet present.");
    }
}
