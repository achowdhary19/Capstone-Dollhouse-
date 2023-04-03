using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class DraggableBrowser : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    /*
    [SerializeField] private AudioSource click; 
    */

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //click.Play();
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Calculate the position to snap to
        Vector2 currentPos = rectTransform.anchoredPosition;
        Vector2 snapPos = new Vector2(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y));

        // Snap to the calculated position
        rectTransform.anchoredPosition = snapPos;
    }
}
