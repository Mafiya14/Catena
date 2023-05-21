using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] private Element _elementPrefab;
    [SerializeField] private GameObject _elementParent;

    [Header("UI")]
    [Range(0f, 1f)]
    [SerializeField] private float _alphaDragValue;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;

    private RectTransform _rectTransform;
    private Canvas _canvas;
    private CanvasGroup _canvasGroup;
    private Vector2 _startPosition;
    private Transform _parentTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _startPosition = _rectTransform.anchoredPosition;
        _parentTransform = transform.parent;

        SetItemInfo();
    }

    private void SetItemInfo()
    {
        _image.sprite = _elementPrefab.Image;
        _name.text = _elementPrefab.Name;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = _rectTransform.position;
        transform.SetParent(_parentTransform.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        _canvasGroup.alpha = _alphaDragValue;
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
                _rectTransform.anchoredPosition = _startPosition;
            }
        }
        else
        {
            _rectTransform.anchoredPosition = _startPosition;
        }

        _canvasGroup.alpha = 1;
        transform.SetParent(_parentTransform);
    }

    private void SpawnElement(Vector3 position, float yRotation)
    {
        Vector3 rotation = new(_elementPrefab.Rotation.x, yRotation, _elementPrefab.Rotation.z);
        var elementObject = Instantiate(_elementPrefab.gameObject, position + _elementPrefab.SpawnOffset, Quaternion.identity);
        elementObject.transform.Rotate(rotation, Space.World);
        elementObject.transform.parent = _elementParent.transform;
    }
}
