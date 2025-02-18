using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
public class Helicopter : MonoBehaviour
{
    [SerializeField] private HelicopterParameters _parameters;
    [SerializeField] private Transform _propeller;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private PropellerRotator.RotationAxis _rotationAxis;

    private Rigidbody _rigidbody;

    private HelicopterMover _helicopterMover;
    private PropellerRotator _propellerRotator;

    public bool IsMoving => _inputHandler.MoveDirection != Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _propellerRotator = new PropellerRotator(_propeller, _rotationAxis, _parameters);
        _helicopterMover = new HelicopterMover(transform, _rigidbody, _parameters);
    }

    private void OnEnable()
    {
        _inputHandler.Up += _helicopterMover.OnUp;
        _inputHandler.Down += _helicopterMover.OnDown;
    }

    private void OnDisable()
    {
        _inputHandler.Up -= _helicopterMover.OnUp;
        _inputHandler.Down -= _helicopterMover.OnDown;
    }

    private void Update()
    {
        _propellerRotator.Rotate(_helicopterMover.HeightCoefficient);
        _helicopterMover.Update(_inputHandler.MoveDirection);
    }

    private void FixedUpdate()
    {
        _helicopterMover.FixedUpdate(_inputHandler.MoveDirection);
    }
}