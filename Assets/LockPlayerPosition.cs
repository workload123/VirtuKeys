using UnityEngine;

public class LockPlayerPosition : MonoBehaviour
{
    public Vector3 fixedPosition; // Set this to the desired position in front of the desk.

    void LateUpdate()
    {
        // Lock the XR Origin position to the fixed position
        transform.position = fixedPosition;
    }
}
