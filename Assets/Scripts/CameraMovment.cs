using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform snake;
    private float cameraOffset;

    void Start()
    {
        cameraOffset = -6.0f;
    }

    void FixedUpdate()
    {
        int count = snake.transform.childCount;
        transform.position = new Vector3(transform.position.x, transform.position.y, snake.GetChild(0).position.z + cameraOffset);
    }
}

