using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1f;

    private Stack<Vector2> positionStack = new Stack<Vector2>();

    private Vector2 currentPosition;

    void Start()
    {
        currentPosition = transform.position;
    }
    private void Update()
    {
        Vector2 newPosition = currentPosition;


        if (Input.GetKeyDown(KeyCode.A) && currentPosition.x >= -3.49)
        {
            newPosition += Vector2.left * moveDistance;
        }

        if (Input.GetKeyDown(KeyCode.D) && currentPosition.x <= 3.50)
        {
            newPosition += Vector2.right * moveDistance;
        }

        if (Input.GetKeyDown(KeyCode.W) && currentPosition.y <= 3.49)
        {
            newPosition += Vector2.up * moveDistance;
        }

        if (Input.GetKeyDown(KeyCode.S) && currentPosition.y >= -3.50)
        {
            newPosition += Vector2.down * moveDistance;
        }

        if (newPosition != currentPosition)
        {
            positionStack.Push(currentPosition);
            currentPosition = newPosition;
            transform.position = currentPosition;
        }

        if (Input.GetKeyDown(KeyCode.Z) && positionStack.Count > 0)
        {
            currentPosition = positionStack.Pop();
            transform.position = currentPosition;
        }
    }
}
