﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float cameraY;
    // Start is called before the first frame update
    void Start()
    {
        cameraY = Camera.main.transform.position.y - 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Deactive();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y -= moveSpeed * Time.deltaTime;
        transform.position = temp;
    }

    void Deactive()
    {
        if(transform.position.y < cameraY)
        {
            gameObject.SetActive(false);
        }
    }
}
