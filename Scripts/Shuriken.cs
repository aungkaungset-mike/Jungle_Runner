﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private bool attackRight;


    public float attackSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-45f,45f )));
        if(transform.position.x > 0)
        {
            attackRight = false;
        }
        else
        {
            attackRight = true;
        }
        Invoke("Deactive", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackRight)
        {
            transform.position -= Vector3.right * attackSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * attackSpeed * Time.deltaTime;
        }
    }
    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
