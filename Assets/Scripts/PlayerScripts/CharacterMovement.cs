using UnityEngine;

[RequireComponent(typeof(CapsuleCollider), typeof(Runner), typeof(Crawler))]
public class CharacterMovement : MonoBehaviour
{
    private const int ZeroValue = 0;

    [SerializeField] private MovementSettings _settings;

    private Runner _runner;
    private Crawler _crawler;

    private void Awake()
    {
        _runner = GetComponent<Runner>();
        _crawler = GetComponent<Crawler>();
    }

    public void Move(float horizontalDirection, float verticalDirection)
    {
        float _currentMoveSpeed = GetCurrentSpeed();

        Vector3 direction = new Vector3(horizontalDirection, ZeroValue, verticalDirection).normalized;
        Vector3 movement = direction * _currentMoveSpeed * Time.fixedDeltaTime;

        transform.Translate(movement);
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