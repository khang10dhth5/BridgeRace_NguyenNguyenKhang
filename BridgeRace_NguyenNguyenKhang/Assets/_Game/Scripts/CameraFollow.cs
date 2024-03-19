using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : SingletonMono<CameraFollow>
{
    public Transform target;

    [SerializeField] private Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = target.position + offset;
            transform.rotation = target.rotation;
            transform.LookAt(target);
        }
    }
}
