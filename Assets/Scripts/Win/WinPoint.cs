using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPoint : MonoBehaviour
{
    [SerializeField] private GameObject _gameplay;
    [SerializeField] private Canvas _winPanel;
    [SerializeField] private Canvas _scorePanel;
    [SerializeField] private Button _restartButton;

    private Action _onRestart;

    private void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
        _winPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            _gameplay.gameObject.SetActive(false);
            _winPanel.gameObject.SetActive(true);
            _scorePanel.gameObject.SetActive(false);
        }
    }

    private void OnRestartButtonClicked()
    {
        _onRestart?.Invoke();
        SceneManager.LoadScene(0);
    }
}
