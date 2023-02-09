using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarDriftRightCircle : MonoBehaviour, IDriftCarCircle
{
    [SerializeField] private TextMeshProUGUI _circleScoreText;
    [SerializeField] private Button _startDriftButton;
    private bool _isDriftCar = false;

    private CarMovement _carMovement;

    private void Awake()
    {
        _startDriftButton.gameObject.SetActive(false);
        _carMovement = FindObjectOfType<CarMovement>();
        _circleScoreText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            _circleScoreText.gameObject.SetActive(true);
            ScoreSystem.CircleScore = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            _startDriftButton.gameObject.SetActive(true);
            DriftCar();
            ScoreSystem.CircleScore++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            _circleScoreText.gameObject.SetActive(false);
            ScoreSystem.mainScore += ScoreSystem.CircleScore;
        }
    }

    public void DriftCar()
    {
        if (_isDriftCar)
        {
            float newRotation = _carMovement.turnSpeed * Time.deltaTime;
            _carMovement.gameObject.transform.Rotate(0, newRotation, 0, Space.World);
        }
    }

    public void OnPressButtonToDrift()
    {
        _isDriftCar = true;
    }

    public void OnReleaseButtonToDrift()
    {
        _isDriftCar = false;
    }
}
