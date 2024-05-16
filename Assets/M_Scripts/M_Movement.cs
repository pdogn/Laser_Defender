using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Movement : MonoBehaviour
{

    Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    public float speed = 3;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Vector2 mindBounds;
    Vector2 maxBounds;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        InputAction();
    }

    private void FixedUpdate()
    {
        Movement_Rotation();

    }

    void InputAction()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void InitBounds()
    {
        mindBounds = new Vector2(-25, -25);
        maxBounds = new Vector2(25, 25);
    }

    void Movement_Rotation()
    {
        //rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        Vector2 delta = movement * speed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, mindBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, mindBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;

        //rb.AddRelativeForce(Vector3.up * movement.y * speed);
        //rb.AddRelativeForce(Vector3.right * movement.x * speed, ForceMode2D.Force);

        Vector2 lookdir = mousePos - rb.position;
        float Angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = Angle;
    }
}
