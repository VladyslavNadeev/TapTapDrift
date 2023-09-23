using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Services.Factories.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseObstacle : MonoBehaviour
{
    private GameObject _gameHud;
    private GameObject _looseWindow;

    public void Init(GameObject gameHud, GameObject looseWindow)
    {
        _looseWindow = looseWindow;
        _gameHud = gameHud;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarMovement>())
        {
            CarMovement carMovement = other.GetComponent<CarMovement>();
            carMovement.EndMoving();
            _gameHud.SetActive(false);
            _looseWindow.SetActive(true);
        }
    }
}
