using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PipeWithDamper : PipeSection
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _raisedPosition;
    [SerializeField] private Transform _damper;
    [SerializeField] private BoxCollider _damperCollider;

    private float _loweredPosition;
    private bool _damperIsRaised;
    private bool _isMoving;

    private void Start()
    {
        _loweredPosition = _damper.localPosition.y;
    }

    private void OnMouseUp()
    {
        if (_isMoving || GameStateController.Instance.CurrentState == GameStateController.States.Testing)
            return;

        if (_damperIsRaised)
        {
            Move(_loweredPosition);
            _damperIsRaised = false;
        }
        else
        {
            Move(_raisedPosition);
            _damperIsRaised = true;
        }
    }

    private async void Move(float end)
    {
        Vector3 targetPosition = new(_damper.localPosition.x, end, _damper.localPosition.z);
        _isMoving = true;

        while (_damper.localPosition != targetPosition)
        {
            _damper.localPosition = Vector3.MoveTowards(_damper.localPosition, targetPosition, _moveSpeed * Time.deltaTime);

            await Task.Yield();
        }

        _isMoving = false;
    }

    public override void Visit(CharacterBase character)
    {
        if (!_damperIsRaised)
        {
            _damperCollider.enabled = true;
        }
    }
}
