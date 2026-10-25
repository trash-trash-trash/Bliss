using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 mouseDelta;
    public Transform playerHead;

    public float horizontalSensitivity = 0.1f;
    public float verticalSensitivity = 0.1f;
    private float cameraPitch;
    private float cameraYaw;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameraPitch = 0f;
        playerHead.localRotation = Quaternion.identity;

        PlayerControls.Instance.AnnounceMouseLook += OnMouseLook;
    }

    void Update()
    {
        HandleCamera();
    }

    private void OnMouseLook(Vector2 input)
    {
        mouseDelta = input;
    }

    void HandleCamera()
    {
        cameraYaw += mouseDelta.x * horizontalSensitivity;
        cameraPitch -= mouseDelta.y * verticalSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerHead.localRotation = Quaternion.Euler(cameraPitch, cameraYaw, 0f);
    }

    void OnDisable()
    {
        PlayerControls.Instance.AnnounceMouseLook -= OnMouseLook;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}