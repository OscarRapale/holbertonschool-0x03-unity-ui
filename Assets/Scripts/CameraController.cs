using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the Player GameObject
    public GameObject player;

    // Offset between the camera and the player
    private Vector3 offset;

    void Start()
    {
        // Calculate and store the offset value between the camera and the player
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Update the camera's position to maintain the offset
        transform.position = player.transform.position + offset;
    }
}
