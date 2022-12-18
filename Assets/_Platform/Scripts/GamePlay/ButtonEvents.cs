using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    public delegate void ButtonAction();
    public event ButtonAction buttonAction;

    public Button button;
    
    static int _index;

    private bool _condition;
    /*private bool _characterSpeed;
    private bool _bulletSpeed;
    private bool _bulletTimer;
    private bool _doubleShot;*/
    
    
    private void Start()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (_index > 2)
        {
            button.interactable = _condition;
        }
        else
        {
            button.interactable = true;
        }
    }

    public void Triple()
    {
        if (_index > 2 || _condition)
        {
            _index--;
            Debug.Log(_index);
            Shoot.Instance.triple = false;
            _condition = false;
        }
        
        else
        {
            Shoot.Instance.triple = true;
            _index++;
            _condition = true;
            Debug.Log(_index);
        }
        
    }

    public void CharacterSpeed()
    {
        if (_index > 2 || _condition)
        {
            _index--;
            Debug.Log(_index);
            PlayerController.Instance.SetPlayerSpeed();
            _condition = false;
        }
        else
        {
            PlayerController.Instance.GetPlayerSpeed();
            _index++;
            _condition = true;
            Debug.Log(_index);
        }
        
    }

    public void BulletSpeed()
    {
        if (_index > 2 || _condition)
        {
            _index--;
            Debug.Log(_index);
            _condition = false;
            Shoot.Instance.SetBulletSpeed();
        }

        else
        {
            Shoot.Instance.GetBulletSpeed();
            _index++;
            _condition = true;
            Debug.Log(_index);
        }

        
    }

    public void BulletTimer()
    {
        if (_index > 2 || _condition)
        {
            _index--;
            Debug.Log(_index);
            Shoot.Instance.SetTimer();
            _condition = false;
        }
        else
        {
            Shoot.Instance.GetTimer();
            _index++;
            _condition = true;
            Debug.Log(_index);
        }
        
    }

    public void DoubleShot()
    {
        if (_index > 2 || _condition)
        {
            _index--;
            Debug.Log(_index);
            Shoot.Instance.doubleShot = false;
            _condition = false;
        }
        else
        {
            Shoot.Instance.doubleShot = true;
            _index++;
            _condition = true;
            Debug.Log(_index);
        }

        
    }
}
