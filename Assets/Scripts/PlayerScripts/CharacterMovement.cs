using UnityEngine;

[RequireComponent(typeof(CapsuleCollider), typeof(Rigidbody))]
[RequireComponent(typeof(Runner), typeof(Crawler))]
public class CharacterMovement : MonoBehaviour
{
    private const int ZERO_VALUE = 0;

    [SerializeField] private MovementSettings _settings;

    private Rigidbody _rigidbody;
    private Runner _runner;
    private Crawler _crawler;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _runner = GetComponent<Runner>();
        _crawler = GetComponent<Crawler>();
    }

    public void Move(float horizontalDirection, float verticalDirection)
    {
        float _currentMoveSpeed = GetCurrentSpeed();

        Vector3 localDirection = new Vector3(horizontalDirection, ZERO_VALUE, verticalDirection).normalized;
        Vector3 worldDirection = transform.TransformDirection(localDirection);
        Vector3 movement = worldDirection * _currentMoveSpeed;

        _rigidbody.velocity = new Vector3(movement.x, _rigidbody.velocity.y, movement.z);
    }

    private float GetCurrentSpeed()
    {
        if (_crawler.IsCrawling)
            return _settings.CrawlSpeed;

        if (_runner.IsRunning)
            return _settings.RunSpeed;

        return _settings.WalkSpeed;
    }
}