using UnityEngine;
using UnityEngine.Serialization;

public class CarMovement : MonoBehaviour
{
    [SerializeField] [FormerlySerializedAs("forwardSpeed")] private float _forwardSpeed;
    [FormerlySerializedAs("turnSpeed")] [SerializeField] private float _turnSpeed;
    [FormerlySerializedAs("sphereRB")] [SerializeField] private Rigidbody _sphereRB;

    private bool _isGameOn;

    public float TurnSpeed => _turnSpeed;

    public void Init()
    {
        _sphereRB.transform.parent = null;
    }

    public void StartMoving()
    {
        _isGameOn = true;
    }
    
    public void EndMoving()
    {
        _isGameOn = false;
    }

    void Update()
    {
        if (_isGameOn)
        {
            transform.position = _sphereRB.transform.position;

        }
    }

    private void FixedUpdate()
    {
        if (_isGameOn)
        {
            _sphereRB.AddForce(transform.forward * _forwardSpeed, ForceMode.Acceleration);
        }        
    }
}
