using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticaInterpolaciones : MonoBehaviour
{
    public GameObject cubePrefab;  // Prefab del cubo a instanciar
    private Transform cube;  // Referencia al cubo en la escena
    public Vector3 positionA = new Vector3(-3, 0, 0);
    public Vector3 positionB = new Vector3(3, 0, 0);
    public float moveDuration = 2f;
    public float rotationDuration = 1.5f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        if (cube == null)
        {
            GameObject newCube = Instantiate(cubePrefab, positionA, Quaternion.identity);
            cube = newCube.transform;
        }

        initialPosition = cube.position;
        initialRotation = cube.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ExecuteSequence());
        }
    }

    IEnumerator ExecuteSequence()
    {
        // Mover desde A hasta B
        yield return StartCoroutine(MoveCube(positionA, positionB, moveDuration));

        // Esperar 1 segundo
        yield return new WaitForSeconds(1f);

        // Rotar 90 grados en Y de forma suave
        yield return StartCoroutine(RotateCube(Quaternion.Euler(0, 90, 0), rotationDuration));

        // Esperar 1 segundo
        yield return new WaitForSeconds(1f);

        // Volver a la posición y rotación inicial
        yield return StartCoroutine(MoveCube(positionB, initialPosition, moveDuration));
        yield return StartCoroutine(RotateCube(initialRotation, rotationDuration));
    }

    IEnumerator MoveCube(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            cube.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cube.position = end;
    }

    IEnumerator RotateCube(Quaternion targetRotation, float duration)
    {
        float elapsed = 0;
        Quaternion startRotation = cube.rotation;
        while (elapsed < duration)
        {
            cube.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cube.rotation = targetRotation;
    }
}

