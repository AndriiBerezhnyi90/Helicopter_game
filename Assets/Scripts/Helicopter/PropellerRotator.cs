using UnityEngine;

public class PropellerRotator
{
    private Transform _propeller;
    private Vector3 _rotation;
    private RotationAxis _rotationAxis;

    private float _speed;
    private float _minSpeed;
    private float _maxSpeed;
    private float _rotateDegree;
    private bool _inverseRotation;

    public PropellerRotator (Transform propeller,RotationAxis axis, HelicopterParameters parameters)
    {
        _propeller = propeller;
        _speed = _minSpeed = parameters.MinPropellerSpeed;
        _maxSpeed = parameters.MaxMainPropellerSpeed;
        _inverseRotation = parameters.IsInverseRotation;
        _rotation = _propeller.eulerAngles;
        _rotationAxis = axis;
    }
    

    public void Rotate(float speed)
    {
        _speed = speed * Time.deltaTime * _maxSpeed;

        if (_inverseRotation)
            _rotateDegree -= _speed;
        else
            _rotateDegree += _speed;

        _rotateDegree %= 360;

        switch (_rotationAxis)
        {
            case RotationAxis.x:
                _propeller.localRotation = Quaternion.Euler(_rotateDegree,_rotation.y , _rotation.z);
                break;
            case RotationAxis.z:
                _propeller.localRotation = Quaternion.Euler(_rotation.x, _rotation.y, _rotateDegree);
                break;
            default:
                _propeller.localRotation = Quaternion.Euler(_rotation.x, _rotateDegree, _rotation.z);
                break;
        }
    }

    public enum RotationAxis
    {
        x, y, z
    }
}