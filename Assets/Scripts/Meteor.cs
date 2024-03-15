using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] float speedDown;
    [SerializeField] float rotateSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        // L?y Rigidbody2D c?a GameObject
        rb = GetComponent<Rigidbody2D>();
        // Thi?t l?p v?n t?c ban ð?u
        rb.velocity = new Vector2(0, -speedDown);
    }
    void Update()
    {
        //transform.Translate(0, -1 * speedDown * Time.deltaTime, 0);

        if(transform.position.y <= -12)
        {
            Destroy(gameObject);
        }

        // Xoay thiên th?ch theo tr?c Z v?i t?c ð? ð? ð?t
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

    }
}
