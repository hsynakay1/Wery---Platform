using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.Translate(transform.forward * (Shoot.Instance.bulletSpeed * Time.deltaTime));
    }

    
}
