using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float cameraSpeed;
    public float mouseSensitivity;
    public float minFov;
    public float maxFov;
    public float zoomSensitivity;
    Vector3 anchorPoint;
    Quaternion anchorRot;

    public float horizontalBounds;
    public float forwardBounds;
    public float ceilingBounds;
    public float floorBounds;

    private void Start()
    {
        if (GameData.MapSize == "Small" || GameData.MapSize == null)
        {
            horizontalBounds = 110f;
            forwardBounds = 110f;
        }
        if (GameData.MapSize == "Medium")
        {
            horizontalBounds = 220f;
            forwardBounds = 220f;
        }
        if (GameData.MapSize == "Large")
        {
            horizontalBounds = 330f;
            forwardBounds = 330f;
        }
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            move += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            move -= Vector3.forward;
        if (Input.GetKey(KeyCode.D))
            move += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            move -= Vector3.right;
        if (Input.GetKey(KeyCode.E))
            move += Vector3.up;
        if (Input.GetKey(KeyCode.Q))
            move -= Vector3.up;


        transform.Translate(move * cameraSpeed * Time.unscaledDeltaTime, Space.Self);

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, -horizontalBounds, horizontalBounds),
          Mathf.Clamp(transform.position.y, floorBounds, ceilingBounds),
          Mathf.Clamp(transform.position.z, -forwardBounds, forwardBounds));

        if (Input.GetMouseButtonDown(1))
        {
            anchorPoint = new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            anchorRot = transform.rotation;
        }

        if (Input.GetMouseButton(1))
        {
            Quaternion rot = anchorRot;
            Vector3 dif = anchorPoint - new Vector3(Input.mousePosition.y, -Input.mousePosition.x);
            rot.eulerAngles += dif * mouseSensitivity * Time.unscaledDeltaTime;
            transform.rotation = rot;
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            UpdateZoom();
        }
    }

    void UpdateZoom()
    {
        float z = Input.GetAxis("Mouse ScrollWheel") * -zoomSensitivity;

        Camera.main.fieldOfView += z;
        if (Camera.main.fieldOfView < minFov)
        {
            Camera.main.fieldOfView = minFov;
        }

        else if (Camera.main.fieldOfView > maxFov)
        {
            Camera.main.fieldOfView = maxFov;
        }
    }
}