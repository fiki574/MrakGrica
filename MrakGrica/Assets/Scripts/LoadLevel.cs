using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
    public string ID;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (ID == "LoadLevel2")
            Initiate.Fade("Level2", Color.black, 0.50f);            
        else if (ID == "LoadLevel3")
            Initiate.Fade("Level3", Color.black, 0.50f);
        else
            return;
    }
}
