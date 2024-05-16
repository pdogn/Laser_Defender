using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        Following();
    }

    void Following()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
    }

}
