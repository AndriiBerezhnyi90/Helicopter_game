using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _yOffset;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _zOffset;
    
    private Transform _target;
    private Vector3 _position;

    private void Awake()
    {
        _target = FindObjectOfType<Helicopter>().GetComponent<Transform>();

        if (_target == null)
            Debug.LogError("_target == null");
    }

    private void Update()
    {
        _position = new Vector3(_target.position.x + _xOffset, _target.position.y + _yOffset, _target.position.z + _zOffset);
        transform.position = _position;  
    }
}