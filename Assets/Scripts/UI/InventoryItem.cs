using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Element _elementPrefab;
    [SerializeField] private GameObject _elementParent;

    private RectTransform rectTransform;
    private Canvas canvas;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                SpawnElement(hit.collider.transform.position);
                gameObject.SetActive(false);
            }
            else
            {
                rectTransform.anchoredPosition = Vector2.zero;
            }
        }
        else
        {
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    private void SpawnElement(Vector3 position)
    {
        var elementObject = Instantiate(_elementPrefab.gameObject, position + _elementPrefab.SpawnOffset, Quaternion.identity);
        elementObject.transform.parent = _elementParent.transform;
    }
}
