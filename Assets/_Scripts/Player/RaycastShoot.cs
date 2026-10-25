using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShoot : MonoBehaviour
{
    public Camera playerCamera;
    public float rayDistance = 100f;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
            Shoot();
    }

    void Shoot()
    {
        Ray ray = playerCamera.ScreenPointToRay(
            Mouse.current.position.ReadValue()
        );

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            Debug.Log("Hit: " + hit.collider.name);
            Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.yellow, 2f);
        }
    }
}