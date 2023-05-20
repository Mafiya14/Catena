using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject _elementPrefab;
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
        /*if (eventData.pointerEnter == null || eventData.pointerEnter.transform.parent != canvas.transform)
        {
            // ������ �� ��� ������� �� �����
            // ��������� ������ ��������, ��������, ������� ������ ��� ������� ��� �� �������� �������
            rectTransform.anchoredPosition = Vector2.zero;
        }
        else
        {
            // ������ ��� ������� �� �����
            // �������� ��� ����������� ������ �� ������ ���������� �� �����
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            worldPosition.z = 0f;
            // �������� ��� ����������� ������ �� worldPosition
            Instantiate(_elementPrefab, worldPosition, Quaternion.identity);
        }*/

        /*Vector3 worldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPosition.z = 12f;
        // �������� ��� ����������� ������ �� worldPosition
        Instantiate(_elementPrefab, worldPosition, Quaternion.identity);*/

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                Debug.Log(hit.collider.name);
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
}
