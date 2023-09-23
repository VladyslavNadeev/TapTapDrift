using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPoint : MonoBehaviour
{
    private GameObject _gameHud;
    private GameObject _winWindow;

    public void Init(GameObject gameHud, GameObject winWindow)
    {
        _winWindow = winWindow;
        _gameHud = gameHud;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            CarMovement carMovement = other.GetComponent<CarMovement>();
            carMovement.EndMoving();
            _gameHud.SetActive(false);
            _winWindow.SetActive(true);
        }
    }
}
