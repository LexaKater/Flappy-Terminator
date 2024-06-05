using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(InputProcessing))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
  
    private InputProcessing _input;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _startPosition = transform.position;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputProcessing>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void FixedUpdate()
    {
        if (_input.TryJump())
            Jump();

        Rotate();
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }

    private void Rotate() => transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
}
