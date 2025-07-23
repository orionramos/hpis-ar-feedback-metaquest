using UnityEngine;

/// <summary>
/// Suaviza la posici�n y rotaci�n de un objeto para seguir la cabeza.
/// </summary>
public class HeadLockedUI : MonoBehaviour
{
    [Tooltip("Ancla de la c�mara (CenterEyeAnchor).")]
    public Transform centerEyeAnchor;

    [Tooltip("Velocidad de interpolaci�n de posici�n.")]
    public float positionLerpSpeed = 10f;

    [Tooltip("Velocidad de interpolaci�n de rotaci�n.")]
    public float rotationLerpSpeed = 10f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void LateUpdate()
    {
        if (centerEyeAnchor == null) return;

        // Calcula objetivo: posici�n un metro frente al ojo
        targetPosition = centerEyeAnchor.position + centerEyeAnchor.forward * 1f;
        targetRotation = centerEyeAnchor.rotation;

        // Suaviza movimiento y rotaci�n
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * positionLerpSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationLerpSpeed);
    }
}
