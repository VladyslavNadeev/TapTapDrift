using System;
using UnityEngine;

public class CarDriftCircle : MonoBehaviour, IDriftCarCircle
{
    [SerializeField] private DriftCircleState _driftCircleState;
    
    private bool _isDriftCar;

    private CarMovement _carMovement;
    private UIStartDriftButton _uiStartDriftButton;

    public void Init(CarMovement carMovement, UIStartDriftButton uiStartDriftButton)
    {
        _uiStartDriftButton = uiStartDriftButton;
        _uiStartDriftButton.gameObject.SetActive(false);
        _uiStartDriftButton.OnStartDriftButtonTaped += OnPressButtonToDrift;
        _carMovement = carMovement;
    }

    private void OnPressButtonToDrift(bool isTaped)
    {
        _isDriftCar = isTaped;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            _uiStartDriftButton.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            DriftCar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            _isDriftCar = false;
            _uiStartDriftButton.gameObject.SetActive(false);
        }
    }

    public void DriftCar()
    {
        if (!_isDriftCar) return;
        
        switch (_driftCircleState)
        {
            case DriftCircleState.LeftCircle:
            {
                var newRotationLeft = -_carMovement.TurnSpeed * Time.deltaTime;
                _carMovement.gameObject.transform.Rotate(0, newRotationLeft, 0, Space.World);
                break;
            }
            case DriftCircleState.RightCircle:
            {
                var newRotationRight = _carMovement.TurnSpeed * Time.deltaTime;
                _carMovement.gameObject.transform.Rotate(0, newRotationRight, 0, Space.World);
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}