using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastShoot : MonoBehaviour
{
    public Camera playerCamera;
    public float rayDistance = 100f;
    
    public ParticleSystem projectileEffect;
    public float projectileSpeed = 100f;
    
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

        StartCoroutine(TravelEffect(ray.origin, ray.direction * rayDistance));
    }

    IEnumerator TravelEffect(Vector3 pointA, Vector3 pointB)
    {
        projectileEffect.transform.position = pointA;
        projectileEffect.transform.rotation =
            Quaternion.LookRotation(pointB - pointA);

        projectileEffect.Play();

        float distance = Vector3.Distance(pointA, pointB);
        float duration = distance / projectileSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float progress = elapsed / duration;

            projectileEffect.transform.position =
                Vector3.Lerp(pointA, pointB, progress);

            elapsed += Time.deltaTime;
            yield return null;
        }

        projectileEffect.transform.position = pointB;
        projectileEffect.Stop();
        projectileEffect.Clear();
    }
}