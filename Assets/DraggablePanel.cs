using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggablePanel : MonoBehaviour, IDragHandler
{
    
    public Scrollbar scrollbar;

    private Vector2 pointerOffset;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pointerPosition = ClampToViewport(eventData.position + pointerOffset);

        // Set the scrollbar value based on the current pointer position
        scrollbar.value = 1 - (pointerPosition.y - scrollbar.GetComponent<RectTransform>().rect.yMin) / scrollbar.GetComponent<RectTransform>().rect.height;
    }

    private Vector2 ClampToViewport(Vector2 position)
    {
        // Clamp the pointer position to the panel's viewport
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        Rect rect = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        position.x = Mathf.Clamp(position.x, rect.xMin, rect.xMax);
        position.y = Mathf.Clamp(position.y, rect.yMin, rect.yMax);

        return position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerOffset = GetComponent<RectTransform>().anchoredPosition - eventData.position;
    }
}
