using System.Collections;
using UnityEngine;

public class BatteryBox : MonoBehaviour
{
    [SerializeField] private Transform _switch;
    [SerializeField] private Transform _pivotPoint;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationAngle;

    private Quaternion _targetRotation;

    private void Start()
    {
        _targetRotation = Quaternion.Euler(_rotationAngle, 90f, -90f);
    }

    private void OnEnable()
    {
        LevelUI.OnStartButtonClicked += RotateSwitch;
    }

    private void OnDisable()
    {
        LevelUI.OnStartButtonClicked -= RotateSwitch;
    }

    private void RotateSwitch()
    {
        StartCoroutine(RotateSmoothly());
    }

    private IEnumerator RotateSmoothly()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = _switch.transform.rotation;

        while (elapsedTime < _rotationSpeed)
        {
            float t = elapsedTime / _rotationSpeed;
            Quaternion currentRotation = Quaternion.Lerp(startRotation, _targetRotation, t);
            _switch.transform.rotation = currentRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _switch.transform.rotation = _targetRotation;
    }
}
