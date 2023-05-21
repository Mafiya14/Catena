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
            if (hit.transform.gameObject.TryGetComponent(out Container container))
            {
                SpawnElement(hit.collider.transform.position, container.Rotation.y);
                hit.transform.gameObject.SetActive(false);
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

    private void SpawnElement(Vector3 position, float yRotation)
    {
        Vector3 rotation = new(_elementPrefab.Rotation.x, yRotation, _elementPrefab.Rotation.z);
        var elementObject = Instantiate(_elementPrefab.gameObject, position + _elementPrefab.SpawnOffset, Quaternion.identity);
        elementObject.transform.Rotate(rotation, Space.World);
        elementObject.transform.parent = _elementParent.transform;
    }
}
