using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    bool isPressed = false;

    private void OnMouseDown()
    {
        isPressed = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }
}
