using UnityEngine;

public class LockPlayerPosition : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the XR Rig
        initialPosition = transform.position;
    }

    void Update()
    {
        // Lock the XR Rig's position to the initial position
        transform.position = initialPosition;
    }
}
