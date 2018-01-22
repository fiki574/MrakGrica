using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayCont : MonoBehaviour {

    private float Health;
    public Text HealthUI;

    void Start()
    {
        Health = 100;
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0.0f) Kill();
        HealthUI.text = System.Convert.ToInt32(Health).ToString();
    }

    public float GetHealth()
    {
        return Health;
    }

    public void Kill()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("YouDied", LoadSceneMode.Additive);
    }
}
