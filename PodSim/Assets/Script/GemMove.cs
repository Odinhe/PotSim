using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GemMove : MonoBehaviour
{
    private Vector3 setMouse;
    [SerializeField] private Text warning;
    bool isDragging = false;
    bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string dragMessage = (isMoving == true) ? "You are grabbing an element!" : "You are not grabbing anything!";
        Debug.Log(dragMessage);
        warning.text = dragMessage;
        //if player is dragging the right mouse, then the position of the item changes based on the position of the mouse in the world
        if (isDragging)
        {
            transform.position = GetMousePosition() + setMouse;
        }
    }
    private void OnMouseDown()
    {
        // when mouse is click down, culculate the difference between the mouse and the item then get the item to the middle of the mouse, then set isDragging to true
        setMouse = transform.position - GetMousePosition();
        isDragging = true;
        isMoving = true;
    }
    private void OnMouseUp()
    {
        //when the mouse is not clicked, set the isDragging to false
        isDragging = false;
        isMoving = false;
    }

    //get where the position of the mouse position
    private Vector3 GetMousePosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 15;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}


