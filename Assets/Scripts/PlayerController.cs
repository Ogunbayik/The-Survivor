using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    [SerializeField] private float movementSpeed;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;
    private bool isMove;
    void Start()
    {
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
            isMove = true;

        if (isMove)
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

}
