using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    
    public static CarMovement instance;

    public Rigidbody sphereRB;

    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    private bool _isGameOn = false;


    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        sphereRB.transform.parent = null;
    }


    void Update()
    {
        if (_isGameOn)
        {
            transform.position = sphereRB.transform.position;

        }
    }

    private void FixedUpdate()
    {
        if (_isGameOn)
        {
            sphereRB.AddForce(transform.forward * forwardSpeed, ForceMode.Acceleration);
        }        
    }

    public void OnGameOn()
    {
        _isGameOn = true;
        _startGameButton.gameObject.SetActive(false);
    }


}
