using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour
{
    public string ID;
    public Rigidbody2D Player;
    public AudioSource DoorsOpen, DoorsClose;
    private bool CanTeleport = false;
    private GUIStyle m_BackgroundStyle = new GUIStyle(); 
    private Texture2D m_FadeTexture;               
    private Color m_CurrentScreenOverlayColor = new Color(0, 0, 0, 0);  
    private Color m_TargetScreenOverlayColor = new Color(0, 0, 0, 0);  
    private Color m_DeltaColor = new Color(0, 0, 0, 0);
    private int m_FadeGUIDepth = -1000;

    void OnTriggerEnter2D(Collider2D collider)
    {
        CanTeleport = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        CanTeleport = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
            if (CanTeleport)
            {
                Player.constraints = RigidbodyConstraints2D.FreezeAll;
                if(DoorsOpen != null)
                    DoorsOpen.Play();
                StartFade(Color.black, 2.5f);
                StartCoroutine(Teleport());
            }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2);

        if (ID == "KPV1")
            Player.transform.position = new Vector2(9.56f, -6.52f);
        else if (ID == "K0V1")
            Player.transform.position = new Vector2(9.04f, -0.52f);
        else if (ID == "K0V2")
            Player.transform.position = new Vector2(9.56f, -13.1f);
        else if (ID == "K1V1")
            Player.transform.position = new Vector2(9.01f, 3.98f);
        else if (ID == "K1V2")
            Player.transform.position = new Vector2(-0.52f, -5.92f);
        else if (ID == "K2V1")
            Player.transform.position = new Vector2(-9.42f, 9.37f);
        else if (ID == "K2V2")
            Player.transform.position = new Vector2(-9.54f, -0.52f);
        else if (ID == "K3V1")
            Player.transform.position = new Vector2(-9.54f, 4.47f);
        else if (ID == "K0O1")
            Player.transform.position = new Vector2(2.38f, -11.98f);
        else if (ID == "K-1O1")
            Player.transform.position = new Vector2(-12.82f, -18.93f);
        else if (ID == "K-1O2")
            Player.transform.position = new Vector2(2.38f, -5.4f);
        else if (ID == "K-2O1")
            Player.transform.position = new Vector2(-12.82f, -11.98f);
        else if (ID == "K-2O2")
            Player.transform.position = new Vector2(-12.8f, -26.31f);
        else if (ID == "K-3O1")
            Player.transform.position = new Vector2(2.3f, -18.59f);

        Player.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (DoorsClose != null)
            DoorsClose.Play();
        yield return new WaitForSeconds(2);
        Destroy(m_FadeTexture);
        yield return null;
    }

    private void Awake()
    {
        m_FadeTexture = new Texture2D(1, 1);
        m_BackgroundStyle.normal.background = m_FadeTexture;
        SetScreenOverlayColor(m_CurrentScreenOverlayColor);
    }

    private void OnGUI()
    {
        if (m_CurrentScreenOverlayColor != m_TargetScreenOverlayColor)
        {
            if (Mathf.Abs(m_CurrentScreenOverlayColor.a - m_TargetScreenOverlayColor.a) < Mathf.Abs(m_DeltaColor.a) * Time.deltaTime)
            {
                m_CurrentScreenOverlayColor = m_TargetScreenOverlayColor;
                SetScreenOverlayColor(m_CurrentScreenOverlayColor);
                m_DeltaColor = new Color(0, 0, 0, 0);
            }
            else
                SetScreenOverlayColor(m_CurrentScreenOverlayColor + m_DeltaColor * Time.deltaTime);
        }

        if (m_CurrentScreenOverlayColor.a > 0)
        {
            GUI.depth = m_FadeGUIDepth;
            GUI.Label(new Rect(-10, -10, Screen.width + 10, Screen.height + 10), m_FadeTexture, m_BackgroundStyle);
        }
    }

    public void SetScreenOverlayColor(Color newScreenOverlayColor)
    {
        m_CurrentScreenOverlayColor = newScreenOverlayColor;
        m_FadeTexture.SetPixel(0, 0, m_CurrentScreenOverlayColor);
        m_FadeTexture.Apply();
    }

    public void StartFade(Color newScreenOverlayColor, float fadeDuration)
    {
        if (fadeDuration <= 0.0f)
            SetScreenOverlayColor(newScreenOverlayColor);
        else
        {
            m_TargetScreenOverlayColor = newScreenOverlayColor;
            m_DeltaColor = (m_TargetScreenOverlayColor - m_CurrentScreenOverlayColor) / fadeDuration;
        }
    }
}
