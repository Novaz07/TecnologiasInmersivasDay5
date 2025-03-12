using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime); // Rotar sobre el eje Y
    }
}
