using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public float speed;
    public float rotationSpeed;
    public Animator animator;
    
    private Touch _touch;
    private float _fingerPosX;
    private float _fingerEndPosX;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.touchCount > 0 /*&& !EventSystem.current.IsPointerOverGameObject(_touch.fingerId)*/)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 TouchPosition =
                Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 10f));

            PlayerMovement();
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _fingerPosX = TouchPosition.x - transform.position.x;
                    break;
                case TouchPhase.Moved:
                    InputController();
                    

                    break;
            }
        }
    }
    public void Rotation(float speed, GameObject gameObject)
    {
        gameObject.transform.rotation = Quaternion.Euler(0, speed, 0);
    }

    void InputController()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            rotationSpeed = rotationSpeed + finger.deltaPosition.x * Time.deltaTime * 10;
            Rotation(rotationSpeed, gameObject);
        }
    }

    private void PlayerMovement()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        animator.SetTrigger("walk");
    }
    public void GetPlayerSpeed()
    {
        speed *= 2;
    }

    public void SetPlayerSpeed()
    {
        speed /= 2;
    }
    
}
