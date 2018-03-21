
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    [SerializeField]
    public float speed;

    private void FixedUpdate()
    {
        Vector3 desiredPosition= target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;

        transform.LookAt(target);
    }

    public void SmoothRotateLeft()
    {
        transform.Translate(Vector3.right * -1 * speed);
    }

    public void SmoothRotateRight()
    {
        transform.Translate(Vector3.right * speed);
    }
}
