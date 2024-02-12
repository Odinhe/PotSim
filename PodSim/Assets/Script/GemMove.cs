using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GemMove : MonoBehaviour
{
    bool isDragging = false;
    private Vector3 offset;
    [SerializeField] private Text warning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //string deathMessage = (isDragging == true) ? warning.text = "You are grabbing an element!" : warning.text = "You are not grabbing anything!";

        //if player is dragging the right mouse, then the position of the item changes based on the position of the mouse in the world
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }
    private void OnMouseDown()
    {
        // when mouse is click down, culculate the difference between the mouse and the item then get the item to the middle of the mouse, then set isDragging to true
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }
    private void OnMouseUp()
    {
        //when the mouse is not clicked, set the isDragging to false
        isDragging = false;
    }

    //get where the position of the mouse in the world position
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 15;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}


