using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot Instance;
    
    public Transform barrel;

    public float bulletSpeed = 10;
    
    private GameObject _bullet;
    private GameObject _bulletRight;
    private GameObject _bulletLeft;

    public float timer = 3;
    private float _index;

    public bool triple;
    public bool doubleShot;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Shooting();
    }

    private void Update()
    {
        _index += 1 * Time.deltaTime;

        if (GameManager.Instance.gameStade == GameStade.UI) return;
        
        if (_index >= timer)
        {
            Shooting();
            _index = 0;
            if (doubleShot) _index = 2.5f;
            doubleShot = false;
        }

        if (Vector3.Distance(_bullet.transform.position,barrel.position) >= 25f)
        {
            PoolManager.Instance.SetPoolObject(_bullet,0);

            if (_bulletRight == null) return;
            if (_bulletRight.activeSelf)
            {
                PoolManager.Instance.SetPoolObject(_bulletRight,0);
                PoolManager.Instance.SetPoolObject(_bulletLeft,0);
            }
        }
    }

    public void Shooting()
    {
        _bullet = PoolManager.Instance.GetPoolObject(0);
        _bullet.transform.forward = barrel.transform.forward;
        _bullet.transform.position = barrel.position;

        if (triple)
        {
            TripleShot();
        }
    }

    public void TripleShot()
    {
        _bulletLeft = PoolManager.Instance.GetPoolObject(0);
        _bulletLeft.transform.position = barrel.position;
        _bulletLeft.transform.forward = barrel.transform.forward;
        _bulletLeft.transform.eulerAngles = Vector3.up * 27.5f;
        
        _bulletRight = PoolManager.Instance.GetPoolObject(0);
        _bulletRight.transform.position = barrel.position;
        _bulletRight.transform.forward = barrel.transform.forward;
        _bulletRight.transform.eulerAngles = Vector3.down * 27.5f;
    }

    public void GetBulletSpeed()
    {
        bulletSpeed *= 1.5f;
    }

    public void SetBulletSpeed()
    {
        float temp = bulletSpeed / 3;
        bulletSpeed -= temp;
    }

    public void GetTimer()
    {
        timer /= 2;
    }

    public void SetTimer()
    {
        timer *= 2;
    }

    
}
