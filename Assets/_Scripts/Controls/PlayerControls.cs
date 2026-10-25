using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public static PlayerControls Instance;

    public PlayerInputActions inputActions;

    public event Action<bool> AnnounceAnyKeyPressedReleased;
    public event Action<Vector2> AnnounceMove;

    public event Action<Vector2> AnnounceMouseLook;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        inputActions = new PlayerInputActions();

        inputActions.ActionMap.AnyKey.performed += AnyKey;
        inputActions.ActionMap.AnyKey.canceled += AnyKey;

        inputActions.ActionMap.Movement.performed += Movement;
        inputActions.ActionMap.Movement.canceled += Movement;

        inputActions.ActionMap.MouseLook.performed += MouseLook;
        inputActions.ActionMap.MouseLook.canceled += MouseLook;

        inputActions.Enable();
    }


    private void AnyKey(InputAction.CallbackContext input)
    {
        if (input.performed)
            AnnounceAnyKeyPressedReleased?.Invoke(true);
        else if (input.canceled)
            AnnounceAnyKeyPressedReleased?.Invoke(false);
    }

    private void Movement(InputAction.CallbackContext obj)
    {
        AnnounceMove?.Invoke(inputActions.ActionMap.Movement.ReadValue<Vector2>());
    }

    private void MouseLook(InputAction.CallbackContext input)
    {
        AnnounceMouseLook?.Invoke(input.ReadValue<Vector2>());
    }

    void OnDisable()
    {
        inputActions.ActionMap.AnyKey.performed -= AnyKey;
        inputActions.ActionMap.AnyKey.canceled -= AnyKey;
        inputActions.ActionMap.Movement.performed -= Movement;
        inputActions.ActionMap.Movement.canceled -= Movement;
        inputActions.ActionMap.MouseLook.performed -= MouseLook;
        inputActions.ActionMap.MouseLook.canceled -= MouseLook;
    }
}