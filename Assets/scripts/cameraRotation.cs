using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour
{
    [SerializeField]
    private float m_rotationAngle;
    [SerializeField]
    private float m_rotationSpeed;
    private Vector3 m_targetRotation;


      ///////////////////

    public float smoothSpeed = 0.5f;

    //Position
    public Transform player;
    public Vector3 offSet;

    //Rotation
    //Quaternion localRotation;
    Quaternion leftRotation = Quaternion.Euler(new Vector3(0, 90, 0));
    Quaternion rightRotation = Quaternion.Euler(new Vector3(0, -90, 0));

    Vector3 lRotation = new Vector3(0.0f, -90f, 0.0f);
    Vector3 rRotation = new Vector3(0.0f, 90f, 0.0f);

    public void Start()
    {
        m_targetRotation = transform.eulerAngles;



    }



    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
        transform.LookAt(player);

        

    }


    public void SmoothRotateLeft()
        {
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(m_targetRotation), m_rotationSpeed);

        // m_targetRotation.y -= m_rotationAngle;
        transform.Rotate(0, -90, 0);

        transform.LookAt(player);

        }


    public void SmoothRotateRight()
        {
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(m_targetRotation), m_rotationSpeed);

        // m_targetRotation.y += m_rotationAngle;
        transform.Rotate(0, 90, 0);

        transform.LookAt(player);
        }
}
