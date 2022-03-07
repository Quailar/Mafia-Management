using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float sensitivity = 0.1f;

    Vector3 anchorPoint;
    Quaternion anchorRot;

    public float horizontalBounds;
    public float forwardBounds;
    public float ceilingBounds;
    public float floorBounds;
    public float viewRange;

    private void Awake()
    {
        if (GameData.MapSize == "Small")
        {
            horizontalBounds = 100;
            forwardBounds = 100;

        }
        if (GameData.MapSize == "Medium")
        {
            horizontalBounds = 175;
            forwardBounds = 175;
        }
        if (GameData.MapSize == "Large")
        {
            horizontalBounds = 250;
            forwardBounds = 250;
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

        //transform.Translate(move);
        transform.Translate(move * speed * Time.unscaledDeltaTime, Space.Self);

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
            rot.eulerAngles += dif * sensitivity * Time.unscaledDeltaTime;
            transform.rotation = rot;
            // Camera.main.transform.localEulerAngles = new Vector3(
            //     Mathf.Clamp(Camera.main.transform.localEulerAngles.x, -viewRange, viewRange),
            //     Mathf.Clamp(Camera.main.transform.localEulerAngles.y, -360, 360),
            //     Mathf.Clamp(Camera.main.transform.localEulerAngles.z, -360, 360));
        }
    }
}