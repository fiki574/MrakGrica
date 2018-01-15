using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    public void Init()
    {
        Initiate.Fade("Main", Color.black, 0.45f);
    }

    public void BackToMenu()
    {
        Initiate.Fade("Menu 3D", Color.black, 0.40f);
    }
}
