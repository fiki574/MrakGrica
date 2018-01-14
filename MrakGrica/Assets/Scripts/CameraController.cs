using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  
    public float minX, minY, maxX, maxY;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        float x = Mathf.Clamp(player.position.x, minX, maxX), y = Mathf.Clamp(player.position.y, minY, maxY);
        transform.position = new Vector2(x, y);
    }
}
