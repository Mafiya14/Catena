using System.Collections;
using UnityEngine;

public class RotatingElement : MonoBehaviour
{
    private enum RotationAxis
    {
        X,
        Y,
        Z
    }

    [SerializeField] private Transform _objectToRotate;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private RotationAxis _rotationAxis;
    [SerializeField] private float _rotationAngle;

    private Quaternion _targetRotation;

    private void Start()
    {
        switch (_rotationAxis)
        {
            case RotationAxis.X:
                _targetRotation = Quaternion.Euler(_rotationAngle, _objectToRotate.rotation.eulerAngles.y, _objectToRotate.rotation.eulerAngles.z);
                break;
            case RotationAxis.Y:
                _targetRotation = Quaternion.Euler(_objectToRotate.rotation.eulerAngles.x, _rotationAngle, _objectToRotate.rotation.eulerAngles.z);
                break;
            case RotationAxis.Z:
                _targetRotation = Quaternion.Euler(_objectToRotate.rotation.eulerAngles.x, _objectToRotate.rotation.eulerAngles.y, _rotationAngle);
                break;
        }
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
        Quaternion startRotation = _objectToRotate.transform.rotation;

        while (elapsedTime < _rotationSpeed)
        {
            float t = elapsedTime / _rotationSpeed;
            Quaternion currentRotation = Quaternion.Lerp(startRotation, _targetRotation, t);
            _objectToRotate.transform.rotation = currentRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _objectToRotate.transform.rotation = _targetRotation;
    }
}
