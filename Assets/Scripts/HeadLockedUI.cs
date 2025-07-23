using UnityEngine;

/// <summary>
/// Suaviza la posición y rotación de un objeto para seguir la cabeza.
/// </summary>
public class HeadLockedUI : MonoBehaviour
{
    [Tooltip("Ancla de la cámara (CenterEyeAnchor).")]
    public Transform centerEyeAnchor;

    [Tooltip("Velocidad de interpolación de posición.")]
    public float positionLerpSpeed = 10f;

    [Tooltip("Velocidad de interpolación de rotación.")]
    public float rotationLerpSpeed = 10f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void LateUpdate()
    {
        if (centerEyeAnchor == null) return;

        // Calcula objetivo: posición un metro frente al ojo
        targetPosition = centerEyeAnchor.position + centerEyeAnchor.forward * 1f;
        targetRotation = centerEyeAnchor.rotation;

        // Suaviza movimiento y rotación
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * positionLerpSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationLerpSpeed);
    }
}
