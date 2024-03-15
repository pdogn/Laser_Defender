using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // T?c ð? xoay

    void Update()
    {
        // Xoay theo tr?c Y v?i t?c ð? ð? ð?t
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
