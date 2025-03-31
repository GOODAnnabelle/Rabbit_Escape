using UnityEngine;

public class RabbitOrbit : MonoBehaviour
{
    public Transform centerPoint;
    public float rotateAngle = 90f;

    public void RotateClockwise()
    {
        transform.RotateAround(centerPoint.position, Vector3.up, rotateAngle);
    }

    public void RotateCounterClockwise()
    {
        transform.RotateAround(centerPoint.position, Vector3.up, -rotateAngle);
    }
}