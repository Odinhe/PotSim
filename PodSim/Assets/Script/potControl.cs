using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class potControl : MonoBehaviour
{
    bool isDragging = false;
    public RectTransform rectTrans;
    [SerializeField]Vector3 selectedScale = new Vector3(1.2f, 1.2f, 1.2f);
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isDragging)
            {
                rectTrans.localScale = selectedScale;
                Vector3 globalMousePos;
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTrans, eventData.position, eventData.pressEventCamera, out globalMousePos))
                {
                    rectTrans.position = globalMousePos;
                }
                //Another way: control anchoredPosition Vector2 to make it follow the mouse (Not recommended)
                //rectTrans.anchoredPosition = eventData.position - new Vector2(Screen.width / 2, 0);
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isDragging)
            {
                isDragging = false;
                rectTrans.localScale = Vector3.one;
      
            }
        }
    }
}
