using UnityEngine;

public class WalkAudio : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Userinput _input;
    [SerializeField] private AudioSource _source;
    [SerializeField] private float _movementThreshold = 0.5f;

    private float _vSpeed;
    private float _hSpeed;

    void Start()
    {
        if (_input == null)
            Debug.LogError("Userinput not set!", this);

        if (_rigidbody == null)
            Debug.LogError("Rigidbody not set!", this);
    }

    void Update()
    {
        _vSpeed = Mathf.Abs(_rigidbody.velocity.x);
        _hSpeed = Mathf.Abs(_rigidbody.velocity.z);

        if (_hSpeed > _movementThreshold || _vSpeed > _movementThreshold)
        {
            if (_source.isPlaying == false)
                _source.PlayOneShot(_source.clip);
        }
        else
        {
            if (_source.isPlaying)
                _source.Stop();
        }
    }
}