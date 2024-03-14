using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float moveSpeed=0.01f;
    [SerializeField] private float rotationSpeed = 100f;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;
    private Touch touch;
    public override void Start()
    {
        base.Start();
    }
    public override void Onit()
    {
        base.Onit();
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
    }
    private void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                moveDirection = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);
                moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
                moveDirection.Normalize();
                lastMoveDirection = moveDirection;

            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                moveDirection = lastMoveDirection;
            }
            if (moveDirection != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            if (transform.forward.z > 0 && IsStair() && brickStack.Count <= 0)
            {
                return;
            }


            Vector3 newPosition = transform.position + moveDirection * moveSpeed;
            rb.MovePosition(newPosition);

            ChangeAmin(AminState.run.ToString());


        }
        else
        {
            ChangeAmin(AminState.idle.ToString());
        }
    }
    private void Update()
    {

    }
}
