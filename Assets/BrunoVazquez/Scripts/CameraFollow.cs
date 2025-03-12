using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform sphere; // Referencia a la esfera
    public Vector3 offset = new Vector3(0, 8, -5); // Posición desde donde la cámara sigue

    void LateUpdate()
    {
        if (sphere != null)
        {
            transform.position = sphere.position + offset;
            transform.LookAt(sphere.position); // Hace que la cámara mire hacia la esfera
        }
    }
}
