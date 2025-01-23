using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate the Coin 45 degrees per second around the x-axis
        transform.Rotate(45 * Time.deltaTime, 0, 0);
    }
}
