using UnityEngine;

public class LockHeadPosition : MonoBehaviour
{
    private Vector3 initialLocalPosition;

    void Start()
    {
        // Store the initial local position of the camera relative to the Camera Offset
        initialLocalPosition = transform.localPosition;
    }

    void Update()
    {
        // Lock the camera's local position to the initial position
        transform.localPosition = initialLocalPosition;
    }
}
