using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private HelicopterActionMap _inputActions;

    public Vector2 MoveDirection {  get; private set; }
    public UnityAction Up;
    public UnityAction Down;

    private void Awake()
    {
        _inputActions = new HelicopterActionMap();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Moving.Up.performed += UpClick;
        _inputActions.Moving.Down.performed += DownClick;
    }

    private void UpClick(InputAction.CallbackContext obj)
    {
        Up?.Invoke();
    }

    private void DownClick(InputAction.CallbackContext obj)
    {
        Down?.Invoke();
    }

    private void OnDisable()
    {
        _inputActions.Moving.Up.performed -= UpClick;
        _inputActions.Moving.Down.performed -= DownClick;
        _inputActions.Disable();
    }

    private void Update()
    {
        MoveDirection = _inputActions.Moving.Move.ReadValue<Vector2>();
    }
}