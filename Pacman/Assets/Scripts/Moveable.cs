using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Moveable : MonoBehaviour
{
    [SerializeField] private float _speedMetersPerSecond = 25f;
    private Vector3? _destination;
    private Vector3 _startPosition;
    private float _totalLerpDuration;
    private float _elapsedLerpDuration;
    private Action _onCompleteCallBack;

    private void Update()
    {
        if (_destination.HasValue == false)
            return;
        if (_elapsedLerpDuration >= _totalLerpDuration && _totalLerpDuration > 0)
            return;

        _elapsedLerpDuration += Time.deltaTime;
        float percent = (_elapsedLerpDuration / _totalLerpDuration);

        transform.position = Vector3.Lerp(a: _startPosition, b: _destination.Value, percent);
        if (_elapsedLerpDuration >= _totalLerpDuration)
            _onCompleteCallBack?.Invoke();


    }

    public void MoveTo(Vector3 destination, Action onComplete = null)
    {
        var distanceToNextWayPoint = Vector3.Distance(a: transform.position, b: destination);
        _totalLerpDuration = distanceToNextWayPoint / _speedMetersPerSecond;
        _startPosition = transform.position;
        _destination = destination;
        _elapsedLerpDuration = 0f;
        _onCompleteCallBack = onComplete;

    }
}
