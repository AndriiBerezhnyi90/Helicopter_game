using UnityEngine;

[CreateAssetMenu(fileName = "HelicoterParameters",menuName = "HelicopterParameters")]
public class HelicopterParameters : ScriptableObject
{
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _upSpeed;
    [SerializeField] private float _minPropellerSpeed;
    [SerializeField] private float _maxPropellerSpeed;
    [SerializeField] private bool _isInverseRotation;

    public float MaxHeight => _maxHeight;
    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotateSpeed;
    public float UpSpeed => _upSpeed;
    public float MinPropellerSpeed => _minPropellerSpeed;
    public float MaxMainPropellerSpeed => _maxPropellerSpeed;
    public bool IsInverseRotation => _isInverseRotation;
}