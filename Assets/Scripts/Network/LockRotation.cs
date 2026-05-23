using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector3 rot = transform.eulerAngles;

        transform.rotation = Quaternion.Euler(
            0f,
            rot.y,
            0f
        );
    }
}