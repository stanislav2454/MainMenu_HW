using UnityEngine;

public class WalkAudio : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Userinput _input;
    [SerializeField] private AudioSource _source;
    // [SerializeField] private AudioClip _walkSFX;

    private float _vSpeed;
    private float _hSpeed;
    void Start()
    {
        if (_input == null)
            Debug.LogError("Userinput not set!", this);

        if (_rigidbody != null)
            _rigidbody.GetComponent<Rigidbody>();

        //if (_walkSFX == null)
        //    Debug.LogError("walkSFX not set!", this);
    }

    void Update()
    {
        _vSpeed = Mathf.Abs(_input.VerticalDirection);
        _hSpeed = Mathf.Abs(_input.HorizontalDirection);

        //сделать: слишком много вызовов
        if (_hSpeed > 0.8f || _vSpeed > 0.8f)
        //сделать: зависает при вызове
            //while (_hSpeed > 0.8f || _vSpeed > 0.8f)
            _source.PlayOneShot(_source.clip);

        //if (_vSpeed > 0.8f)
        //{
        //    Debug.Log("V_Speed: " + _vSpeed);
        //    _walkSFX.Play();
        //}
        //else if (_hSpeed > 0.8f)
        //{
        //    Debug.Log("H_Speed: " + _hSpeed);
        //    _walkSFX.Play();
        //}
        //if (_hSpeed == 0 || _vSpeed == 0)
        //{
        //    _walkSFX.Stop();
        //}
        ////else
        ////    _walkSFX.Stop();

        ////    Debug.Log("Speed: " + _rigidbody.velocity);

        ////if (_rigidbody.velocity.y > 0)
        ////{
        ////    Debug.Log("Y_speed: " + _rigidbody.velocity);
        ////    _walkSFX.Play();
        ////}
        ////else
        ////    _walkSFX.Stop();
    }
}
